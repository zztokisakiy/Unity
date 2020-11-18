using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyGUI : MonoBehaviour
{
    public int state;

    void Start()
    {
        state = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnGUI()
    {
        GUIStyle style = new GUIStyle
        {
            border = new RectOffset(10, 10, 10, 10),
            fontSize = 20,
            fontStyle = FontStyle.BoldAndItalic,
        };
        style.normal.textColor = new Color(200 / 255f, 180 / 255f, 150 / 255f);    

        if (GUI.Button(new Rect(50, 100, 100, 50), "重新开始"))
        {
            Director.GetInstance().CurrentSceneController.LoadSource();
        }


        style.normal.textColor = new Color(200 / 255f, 200 / 255f, 169 / 255f);
        GUI.Label(new Rect(60, 70, 200, 50), "Score: "+ Singleton<ScoreController>.Instance.GetScore().ToString(), style);

        if(state == 1)
        {
            style.normal.textColor = new Color(252 / 255f, 157 / 255f, 154 / 255f);
            style.fontSize = 50;
            GUI.Label(new Rect(200, 200, 200, 50), "游戏结束，最终得分：" + Singleton<ScoreController>.Instance.GetScore().ToString(), style);
        }

    }



}
