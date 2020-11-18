using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player
{

    private static Player _instance; 

    public static Player GetInstance()
    {
        if (_instance == null)
        {
            _instance = new Player();
        }
        return _instance;
    }

    private Animator animator;
    private AnimatorStateInfo stateinfo;
    GameObject Role;

    private Player()
    {
        Role = GameObject.FindWithTag("Player");
        animator = Role.GetComponent<Animator>();
    }

    private void setStateFalse()
    {
        animator.SetBool("Idle", false);
        animator.SetBool("Forward", false);
        animator.SetBool("Left", false);
        animator.SetBool("Right", false);
        animator.SetBool("Backward", false);
    }

    public void idle()
    {
        if(animator != null)
        {
            setStateFalse();
            animator.SetBool("Idle", true);
        }

    }

    public void forward()
    {
        if (animator != null)
        {
            setStateFalse();
            animator.SetBool("Forward", true);
        }

    }

    public void backward()
    {
        if (animator != null)
        {

        }

            setStateFalse();
        animator.SetBool("Backward", true);
    }

    public void left()
    {
        if (animator != null)
        {
            setStateFalse();
            animator.SetBool("Left", true);
        }

    }

    public void right()
    {
        if (animator != null)
        {
        setStateFalse();
        animator.SetBool("Right", true);
        }

    }

}
