using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirectionScript : MonoBehaviour
{
    public float rotateSpeed = 100f;
    public float slideSpeed = 50f;

    private GameManager gm;
    private PlayerMovement playerMov;
    private GameObject player;

    private void Start()
    {
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
        player = GameObject.FindGameObjectsWithTag("Player")[0];
        playerMov = player.GetComponent<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = player.transform.position;
        float speed;

        if (!playerMov.isRolling())
            speed = rotateSpeed;
        else
            speed = slideSpeed;

        rotate(speed);
            
            
    }

    void rotate(float speed)
    {
        if (gm.leftDown)
        {
            transform.Rotate(Vector3.up * -speed * Time.deltaTime);
        }
        else if (gm.rightDown)
        {
            transform.Rotate(Vector3.up * speed * Time.deltaTime);
        }
    }
}
