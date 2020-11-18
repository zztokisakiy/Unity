using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstSceneController : MonoBehaviour, ISceneController
{
    public Queue<GameObject> soldierQueue = new Queue<GameObject>();
    public GameObject player;
    public GameObject scene;
    public void LoadSource()
    {

        if (scene != null)
        {
            Destroy(scene);
        }
        scene = GameObject.Instantiate<GameObject>(Resources.Load<GameObject>("Prefabs/MyScene"));
        while(soldierQueue.Count > 0)
        {
            GameObject temp = soldierQueue.Dequeue();
            Singleton<SoldierFactory>.Instance.FreeSoldier(temp);
        }
        soldierQueue.Clear();

        for (int i = 0;i < 4;i ++)
        {
            soldierQueue.Enqueue(Singleton<SoldierFactory>.Instance.GetSoldier(i));
        }
        if(player == null)
        {
            player = GameObject.Instantiate<GameObject>(Resources.Load<GameObject>("Prefabs/Role"));
        }
        player.transform.position = new Vector3(15, 0, 12);
        Player.GetInstance().idle();
        player.GetComponent<Rigidbody>().isKinematic = false;
        Singleton<ScoreController>.Instance.MyReset();
        Singleton<MyGUI>.Instance.state = 0;
    }

    void Start()
    {
        Director.GetInstance().CurrentSceneController = this;
        this.gameObject.AddComponent<ScoreController>();
        this.gameObject.AddComponent<SoldierFactory>();
        this.gameObject.AddComponent<MyGUI>();
        this.gameObject.AddComponent<SceneTrigger>();
        Singleton<SceneTrigger>.Instance.Attach((ScoreController)Singleton<ScoreController>.Instance);
        LoadSource();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
