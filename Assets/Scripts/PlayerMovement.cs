using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System;

public class PlayerMovement : MonoBehaviour
{
    public float rollSpeed = 100f;
    public float slideSpeed = 1f;
    public float stoppingSpeed = 1f;

    private Boolean rolling = false;

    public Rigidbody rb;

    private GameObject direction;
    private GameManager gm;

    void Start() {
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
        direction = GameObject.Find("Direction");
    }

    // Update is called once per frame
    void Update() {
        var speed = rb.velocity.magnitude;
        if(rolling) {
            if (speed < stoppingSpeed) {
                standUp();
            } else {
                slide();
            }
        } else{
            if (gm.spaceDown) {
                roll();
            }
        }
    }

    void standUp() {
        transform.localRotation = Quaternion.Euler(-90, 0, 0);
        rb.velocity = Vector3.zero;
        rolling = false;
    }

    void roll()
    {
        //place the roll according to the camera
        transform.localRotation = Quaternion.Euler(0, direction.transform.rotation.eulerAngles.y + 90, 0);

        /* push in the right direction */
        float a = (float) (direction.transform.rotation.eulerAngles.y * (Math.PI / 180));
        float x = (float) Math.Sin(a) * rollSpeed;
        float z = (float) Math.Cos(a) * rollSpeed;
        rb.AddForce(x, 0, z);

        rolling = true;
    }

    void slide()
    {
        Debug.Log(transform.localRotation.eulerAngles);
        float x = transform.localRotation.x;
        float z = transform.localRotation.z;
        transform.localRotation = Quaternion.Euler(x, direction.transform.rotation.eulerAngles.y + 90, z);
    }

    public bool isRolling() {
        return rolling;
    }
}
