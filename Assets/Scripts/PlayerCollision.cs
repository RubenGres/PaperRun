using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    GameManager gm;
    private void Start()
    {
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
    }
    
    void OnCollisionEnter(Collision collision)
    {
        switch (collision.collider.tag) {
            case "Collectable":
                collision.gameObject.SetActive(false);
                gm.addPoints(100);
                break;
        }
    }
}
