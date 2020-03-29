using UnityEngine;
using UnityEngine.UI;


public class GameManager : MonoBehaviour
{
    public bool leftDown, rightDown, upDown, spaceDown, spacePressed, downDown = false;
    private int score = 0;

    public Text scoreText;
    private float timer;
    private void Start()
    {
        
        scoreText.text = "Score : " + score.ToString("0");
    }

    void Update()
    {
        updateKeys();
        addScore();
    }

    void addScore()
    {
        timer += Time.deltaTime;
        if (timer > 5f)
        {
            score += 5;
            scoreText.text = "Score : " + score.ToString("0");
            timer = 0f;
        }
       
    }

    void updateKeys()
    {
        leftDown = Input.GetKey("left") | Input.GetKey("q") | Input.GetKey("a");
        rightDown = Input.GetKey("right") | Input.GetKey("d");
        upDown = Input.GetKey("w") | Input.GetKey("z") | Input.GetKey("up");
        downDown = Input.GetKey("s") | Input.GetKey("down");
        spaceDown = Input.GetKey("space");
        spacePressed = Input.GetKeyDown("space");
    }
}
