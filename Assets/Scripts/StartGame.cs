using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGame : MonoBehaviour
{

    public GameObject gameCamera;
    public GameObject menuCamera;
    public void startGame()
    {
        gameCamera.SetActive(true);
        menuCamera.SetActive(false);
    }
}
