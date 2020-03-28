using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System;

public class PlayerMovement : MonoBehaviour
{
    public float rollSpeed = 50f;
    public float maxspeed = 300f;
    public float maxRotAngle = 30f;
    public float stoppingSpeed = 5f;
    public float jumpForce = 100f;

    private float speed;
    private bool rolling = false;

    private Rigidbody rb;

    private GameObject direction;
    private GameManager gm;
    private DirectionScript dirScript;

    void Start() {
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
        direction = GameObject.Find("Direction");
        dirScript = direction.GetComponent<DirectionScript>();
        rb = gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update() {
        recalculateSpeed();

        if(Math.Abs(rb.velocity.magnitude) < stoppingSpeed) {
            Invoke("standUp", 1);      
        } else {
            rolling = true;
            rotateRoll();
        }
        
        updateVelocity();
    }

    void recalculateSpeed() {
        speed = new Vector2(rb.velocity.x, rb.velocity.z).magnitude * Math.Sign(speed);

        if (gm.upDown)
        {
            speed = speed + (rollSpeed * Time.deltaTime);
        }
        else if (gm.downDown)
        {
            speed = speed - (rollSpeed * Time.deltaTime); ;
        }
        speed = Math.Max(Math.Min(speed, maxspeed), -maxspeed);
    }

    void standUp() {
        if (Math.Abs(rb.velocity.magnitude) < stoppingSpeed) {
            transform.localRotation = Quaternion.Euler(-90, 0, 0);
            rolling = false;
        }
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
        float x = transform.eulerAngles.x;
        float y = direction.transform.rotation.eulerAngles.y + 90;
        float z = transform.eulerAngles.z;

        if(x > maxRotAngle && x < 180) {
            x = maxRotAngle;
        } else if(x > 180 && x < 360 - maxRotAngle) {
            x = 360 - maxRotAngle;
        }

        Vector3 desiredRot = new Vector3(x,y,z);
        transform.rotation = Quaternion.Euler(desiredRot);
    }

    public bool isRolling() {
        return rolling;
    }
}
