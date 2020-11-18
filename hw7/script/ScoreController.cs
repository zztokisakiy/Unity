using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreController :MonoBehaviour, Observer
{
    public int score;

    void Start()
    {
        score = 0;
    }


    public void MyReset()
    {
        score = 0;
    }

    public void MyUpdate()
    {
        score++;
        Debug.Log(score);
    }

    public int GetScore()
    {
        return score;
    }

}
