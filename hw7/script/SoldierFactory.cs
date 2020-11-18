using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoldierFactory : MonoBehaviour
{
    private List<GameObject> used = new List<GameObject>();
    private List<GameObject> free = new List<GameObject>();

    Vector3 []MonsterPos = {
        new Vector3(7, 0, 17) , new Vector3(-7, 0, 17),
        new Vector3(-7, 0, 34) , new Vector3(12, 0, 36)
    };

    public GameObject GetSoldier(int index)
    {
        GameObject newSoldier = null;
        if (free.Count > 0)
        {
            newSoldier = free[0];
            free.Remove(free[0]);
        }
        else
        {
            newSoldier = GameObject.Instantiate<GameObject>(Resources.Load<GameObject>("Prefabs/Monster"));
        }
        newSoldier.transform.position = MonsterPos[index];
        used.Add(newSoldier);
        newSoldier.name = newSoldier.GetInstanceID().ToString();
        newSoldier.SetActive(true);
        return newSoldier;
    }

    public void FreeSoldier(GameObject soldier)
    {
        if (soldier != null)
        {
            used.Remove(soldier);
            soldier.SetActive(false);
            Destroy(soldier);
        }
    }


}
