﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGame : MonoBehaviour
{

    GameManager gm;
    public void startGame()
    {
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
        gm.Init();
    }
}
