using UnityEngine;
using UnityEngine.UI;


public class GameManager : MonoBehaviour
{
    public bool leftDown, rightDown, upDown, spaceDown, spacePressed, downDown = false;
    private int score = 0;

    public Text scoreText, finalScore;
    private float timer;
    bool isRunning = false;

    public GameObject gameCamera, menuCamera, player, GameOverPanel, InGamePanel, PausePanel;

    public void Init()
    {
        scoreText.text = "Score : " + score.ToString("0");
        isRunning = true;
        gameCamera.SetActive(true);
        menuCamera.SetActive(false);
        player.SetActive(true);
        InGamePanel.SetActive(true);
        GameOverPanel.SetActive(false);
        PausePanel.SetActive(false);
    }
    
    void Update()
    {
        updateKeys();
        addScore();
        if (Input.GetKey(KeyCode.Escape))
        {
            gamePause();
        }
    }

    void addScore()
    {
        if (isRunning)
        {
            timer += Time.deltaTime;
            if (timer > 5f)
            {
                score += 5;
                scoreText.text = "Score : " + score.ToString("0");
                timer = 0f;
            }
        }
       
    }

    public void addPoints(int points)
    {
        score += points;
        scoreText.text = "Score : " + score.ToString("0");
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

    public void gameOver()
    {
        finalScore.text = "Your final score : " + score.ToString("0");
    }

    public void gamePause()
    {
        PausePanel.SetActive(true);
        InGamePanel.SetActive(false);
        isRunning = false;
        Time.timeScale = 1;
    }

    public void gameResume()
    {
        PausePanel.SetActive(false);
        InGamePanel.SetActive(true);
        isRunning = true;
        Time.timeScale = 1;
    }

    public void exitGame()
    {
        gameCamera.SetActive(false);
        menuCamera.SetActive(true);
        InGamePanel.SetActive(false);
        GameOverPanel.SetActive(false);
        isRunning = false;
    }

}
