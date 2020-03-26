using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turn : MonoBehaviour
{

    public float rotateSpeed = 50f;
    public float rollSpeed = 100f;
    public Rigidbody rb;

    // Update is called once per frame
    void Update()
    {
        rotate();

        if (Input.GetKey("space"))
            roll();
    }

    void rotate()
    {
        if (Input.GetKey("left"))
        {
            transform.Rotate(Vector3.up * rotateSpeed * Time.deltaTime);
        }
        else if (Input.GetKey("right"))
        {
            transform.Rotate(Vector3.up * -rotateSpeed * Time.deltaTime);
        }
    }

    void roll()
    {
        Vector3 rotation = rb.transform.rotation.eulerAngles;
        float x = rotation.x * rollSpeed * Time.deltaTime;
        float y = rotation.x * rollSpeed * Time.deltaTime;
        float z = rotation.z * rollSpeed * Time.deltaTime;

        rb.AddForce(100, 0, 100);
    }
}
