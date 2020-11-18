using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneTrigger : MonoBehaviour
{
    public List<Observer> observers = new List<Observer>();
    public void Attach(Observer o)
    {
        observers.Add(o);
        o.MyUpdate();

    }
    public void Detach(Observer o)
    {
        observers.Remove(o);
    }
    public void Notify()
    {
        foreach (Observer o in observers)
        {
            o.MyUpdate();
        }
        Singleton<ScoreController>.Instance.MyUpdate();
    }


    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player" )
        {
            Notify();
        }
    }

}
