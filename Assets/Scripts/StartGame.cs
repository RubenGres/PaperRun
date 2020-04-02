using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGame : MonoBehaviour
{

    public GameObject gameCamera;
    public GameObject menuCamera;
    public GameObject player;
    public void startGame()
    {
        gameCamera.SetActive(true);
        menuCamera.SetActive(false);
        player.SetActive(true);
    }
}
