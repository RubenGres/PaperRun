using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    public bool leftDown, rightDown, upDown, spaceDown, spacePressed, downDown = false;
    private int score = 0;

    public Text scoreText, finalScore;
    private float timer;

    public GameObject particles;
    public GameObject zombie;

    public int spawnTimer = 20;
    private float stimer;

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

        processCollectables();
    }
    
    void Update()
    {
        if (isRunning)
        {
            updateKeys();
            addScore();
            spawnZombie();
            if (Input.GetKey(KeyCode.Escape))
            {
                gamePause();
            }
        }
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

    void processCollectables() {
        GameObject[] cols = GameObject.FindGameObjectsWithTag("Collectable");
        foreach (var col in cols)
        {
            Instantiate(particles, col.transform);
        }

        Destroy(particles);
    }

    void spawnZombie() {
        stimer += Time.deltaTime;
        if (stimer > spawnTimer)
        {
            GameObject[] spawns = GameObject.FindGameObjectsWithTag("Spawner");
            int r = (int) Random.Range(0, spawns.Length);

            Instantiate(zombie, spawns[r].transform);
            stimer = 0;
        }
    }
    public void gameOver()
    {
        finalScore.text = "Your final score : " + score.ToString("0");
        isRunning = false;

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
        SceneManager.LoadScene("Main");
    }

}
