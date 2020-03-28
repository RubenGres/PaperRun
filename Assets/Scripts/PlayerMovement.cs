using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System;

public class PlayerMovement : MonoBehaviour
{
    public float rollSpeed = 10f;
    public float maxspeed = 300f;
    public float maxRotAngle = 2f;

    private float speed;

    public Rigidbody rb;

    private GameObject direction;
    private GameManager gm;
    private DirectionScript dirScript;

    void Start() {
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
        direction = GameObject.Find("Direction");
        dirScript = direction.GetComponent<DirectionScript>();
    }

    // Update is called once per frame
    void Update() {
        rotateRoll();

        speed = new Vector2(rb.velocity.x, rb.velocity.z).magnitude;
        if (gm.spacePressed) {
            speed = speed + rollSpeed;
        }

        speed = Math.Min(speed, maxspeed);

        updateVelocity();
    }

    void standUp() {
        transform.localRotation = Quaternion.Euler(-90, 0, 0);
        rb.velocity = Vector3.zero;
    }

    void flipSide()
    {
        //place the roll according to the camera
        transform.localRotation = Quaternion.Euler(0, direction.transform.rotation.eulerAngles.y + 90, 0);
    }

    void updateVelocity() {
        float a = (float) (direction.transform.rotation.eulerAngles.y * (Math.PI / 180));
        float x = (float) Math.Sin(a);
        float z = (float) Math.Cos(a);

        Vector3 desiredVelocity = new Vector3(x, 0, z);
        desiredVelocity.Normalize();
        desiredVelocity = desiredVelocity * (speed);

        float y = rb.velocity.y;
        rb.velocity = new Vector3(desiredVelocity.x, y, desiredVelocity.z);
    }

    void rotateRoll()
    {
        float x = 0;
        float y = direction.transform.rotation.eulerAngles.y + 90;
        float z = transform.eulerAngles.z;

        Vector3 desiredRot = new Vector3(x,y,z);
        transform.rotation = Quaternion.Euler(desiredRot);
    }

    public bool isRolling() {
        return true;
    }
}
