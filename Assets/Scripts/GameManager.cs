using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public bool leftDown = false;
    public bool rightDown = false;
    public bool spaceDown = false;
    public bool spacePressed = false;

    // Update is called once per frame
    void Update()
    {
        leftDown = Input.GetKey("left") | Input.GetKey("q") | Input.GetKey("a");
        rightDown = Input.GetKey("right") | Input.GetKey("d");
        spaceDown = Input.GetKey("space");
        spacePressed = Input.GetKeyDown("space");
    }
}
