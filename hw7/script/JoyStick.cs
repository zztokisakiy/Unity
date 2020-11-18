/*JoyStick.cs*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class JoyStick : MonoBehaviour
{

    private float speedX = 150.0F;
    private float speedY = 7.0F;

    void Update()
    {
        float translationY = Input.GetAxis("Vertical") * speedY;
        float translationX = Input.GetAxis("Horizontal") * speedX;
        translationY *= Time.deltaTime;
        translationX *= Time.deltaTime;

        if(this.transform.gameObject.GetComponent<Rigidbody>().isKinematic == false)
        {
            if (translationY > 0)
            {
                transform.Translate(0, 0, translationY);
                Player.GetInstance().forward();
            }
            else if (translationY < 0)
            {
                transform.Translate(0, 0, translationY);
                Player.GetInstance().backward();
            }
            if (translationX > 0)
            {
                Player.GetInstance().right();
                transform.Rotate(0, translationX, 0);
            }
            else if (translationX < 0)
            {
                Player.GetInstance().left();
                transform.Rotate(0, translationX, 0);
            }
            if (translationX == 0 && translationY == 0)
            {
                Player.GetInstance().idle();
            }

            if (Input.GetButtonDown("Fire1"))
            {
                Debug.Log("Fired Pressed");
            }
        }


    }
}