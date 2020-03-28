using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System;

public class PlayerMovement : MonoBehaviour
{
    public float rollSpeed = 100f;
    public float slideSpeed = 100f;
    public float stoppingSpeed = 1f;

    private Boolean rolling = false;

    public Rigidbody rb;
    public GameObject arrow;

    // Update is called once per frame
    void Update()
    {
        var speed = rb.velocity.magnitude;
        if(rolling)
        {
            if (speed < stoppingSpeed)
            {
                {
                    transform.localRotation = Quaternion.Euler(-90, 0, 0);
                    rolling = false;
                }
            } else
            {
                slide();
            }
        } else
        {
            if (Input.GetKey("space"))
            {
                roll();
                rolling = true;
            }
        }
    }

    void roll()
    {
        /* push in the arrow direction */
        float a = (float) (arrow.transform.rotation.eulerAngles.y * (Math.PI / 180));
        float x = (float) Math.Sin(a) * rollSpeed;
        float z = (float) Math.Cos(a) * rollSpeed;
        rb.AddForce(x, 0, z);

        transform.localRotation = Quaternion.Euler(0, arrow.transform.rotation.eulerAngles.y + 90, 0);
    }

    void slide()
    {
        if (Input.GetKey("left"))
        {
            rb.AddRelativeForce(100, 0, 0);
        }
        else if (Input.GetKey("right"))
        {
            rb.AddRelativeForce(-100, 0, 0);
        }
    }
}
