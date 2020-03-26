using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System;

public class Turn : MonoBehaviour
{
    public float rollSpeed = 100f;
    public Rigidbody rb;

    public GameObject arrow;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("space"))
            roll();
    }

    void roll()
    {
        float a = (float) (arrow.transform.rotation.eulerAngles.y * (Math.PI / 180));
        float x = (float) Math.Sin(a) * rollSpeed;
        float z = (float) Math.Cos(a) * rollSpeed;
        rb.AddForce(x, 0, z);
    }
}
