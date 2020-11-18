using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Soldier : MonoBehaviour
{

    private Animator animator;
    private AnimatorStateInfo stateinfo;
    GameObject soldier;
    private int SoldierState = 0;  
    GameObject role;


    private void setStateFalse()
    {
        animator.SetBool("Walk", false);
        animator.SetBool("Run", false);
        animator.SetBool("Jump", false);
    }


    void Start()
    {
        soldier = this.transform.gameObject;
        role = GameObject.FindWithTag("Player");
        animator = soldier.GetComponent<Animator>();
        SoldierState = 0;
        setStateFalse();
        animator.SetBool("Walk", true);
    }

    void Update()
    {
        if (SoldierState == 0)
        {
            float translationZ = 2f;
            translationZ *= Time.deltaTime;
            transform.Translate(0, 0, translationZ);
        }
        else if(SoldierState == 1)
        {
            Vector3 rolepos = role.transform.position;
            float offX = (-rolepos.x + transform.position.x) * Time.deltaTime;
            float offZ = (-rolepos.z + transform.position.z) * Time.deltaTime;
            transform.Translate(offX, 0, offZ);
            if(offZ != 0)
            {
                float angle = Mathf.Atan(Mathf.Abs(offX / offZ))*Time.deltaTime;
                transform.Rotate(new Vector3(0, angle, 0));
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {

    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player" && SoldierState == 0)
        {
            Debug.Log("stay");
            setStateFalse();
            animator.SetBool("Run", true);
            SoldierState = 1;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player" && SoldierState == 1)
        {
            Debug.Log("stay");
            setStateFalse();
            animator.SetBool("Walk", true);
            SoldierState = 0;
        }
    }

    public void TurnRight()
    {
        transform.Rotate(0, 90, 0);
    }

    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.tag == "Wall")
        {
            Debug.Log("WALL");
            TurnRight();
        }
        else if (collision.gameObject.tag == "Player")
        {
            Debug.Log("player");
            setStateFalse();
            animator.SetBool("Jump", true);
            SoldierState = 2;
            //soldier.GetComponent<Rigidbody>().isKinematic = true;
            role.GetComponent<Rigidbody>().isKinematic = true;
            Singleton<MyGUI>.Instance.state = 1;
        }
    }



}
