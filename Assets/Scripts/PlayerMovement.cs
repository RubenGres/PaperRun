using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System;

public class PlayerMovement : MonoBehaviour
{
    public float rollSpeed = 100f;
    public float stoppingSpeed = 1f;

    private Boolean isUpright = true;

    public Rigidbody rb;
    public GameObject arrow;

    // Update is called once per frame
    void Update()
    {
        var speed = rb.velocity.magnitude;
        if (speed < stoppingSpeed)
        {
            if(!isUpright)
            {
                transform.localRotation = Quaternion.Euler(-90, 0, 0);
                isUpright = true;
            }
        }

        if (Input.GetKey("space"))
            roll();
    }

    void roll()
    {
        float a = (float) (arrow.transform.rotation.eulerAngles.y * (Math.PI / 180));
        float x = (float) Math.Sin(a) * rollSpeed;
        float z = (float) Math.Cos(a) * rollSpeed;
        rb.AddForce(x, 0, z);

        if (isUpright)
            transform.localRotation = Quaternion.Euler(0, arrow.transform.rotation.eulerAngles.y + 90, 0);

        isUpright = false;
    }
}
