using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    GameManager gm;
    public GameObject GameOverPanel, InGamePanel;

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
            case "Zombie":
                GameOverPanel.SetActive(true);
                InGamePanel.SetActive(false);
                gm.gameOver();
                break;
            default:
                break;
        }
    }
}
