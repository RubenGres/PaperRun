using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class resumeGame : MonoBehaviour
{
    GameManager gm;

    public void resume()
    {
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
        gm.gameResume();
    }
}
