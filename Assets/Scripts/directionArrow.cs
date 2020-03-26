using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class directionArrow : MonoBehaviour
{

    public GameObject player;
    public float rotateSpeed = 100f;

    // Update is called once per frame
    void Update()
    {
        transform.position = player.transform.position;
        rotate();
    }

    void rotate()
    {
        if (Input.GetKey("left"))
        {
            transform.Rotate(Vector3.up * -rotateSpeed * Time.deltaTime);
        }
        else if (Input.GetKey("right"))
        {
            transform.Rotate(Vector3.up * rotateSpeed * Time.deltaTime);
        }
    }
}
