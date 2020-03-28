using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public bool leftDown, rightDown, upDown, spaceDown, spacePressed, downDown = false;

    // Update is called once per frame
    void Update()
    {
        leftDown = Input.GetKey("left") | Input.GetKey("q") | Input.GetKey("a");
        rightDown = Input.GetKey("right") | Input.GetKey("d");
        upDown = Input.GetKey("w") | Input.GetKey("z") | Input.GetKey("up");
        downDown = Input.GetKey("s") | Input.GetKey("down");
        spaceDown = Input.GetKey("space");
        spacePressed = Input.GetKeyDown("space");
    }
}
