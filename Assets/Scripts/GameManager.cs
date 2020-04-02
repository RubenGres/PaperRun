using UnityEngine;
using UnityEngine.UI;


public class GameManager : MonoBehaviour
{
    public bool leftDown, rightDown, upDown, spaceDown, spacePressed, downDown = false;
    private int score = 0;

    public Text scoreText;
    private float timer;

    public GameObject particles;
    public GameObject zombie;

    public int spawnTimer = 20;
    private float stimer;

    private void Start()
    {
        scoreText.text = "Score : " + score.ToString("0");

        processCollectables();
    }

    void Update()
    {
        updateKeys();
        addScore();
        spawnZombie();
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
}
