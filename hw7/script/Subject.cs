using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Subject
{

    protected List<Observer> observers = new List<Observer>();
    public void attach(Observer o)
    {

    }
    public void detach(Observer o)
    {

    }
    public void notify()
    {
        foreach(Observer o in observers)
        {
            o.MyUpdate();
        }
    }

}
