using UnityEngine;

public class backtomenu : MonoBehaviour
{
    GameManager gm;
    public void back()
    {
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
        gm.exitGame();
    }
}
