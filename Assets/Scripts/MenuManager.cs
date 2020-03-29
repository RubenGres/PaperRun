using UnityEngine;
using System;
using System.IO;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{

    public int points = 0;
    private string scorePath;
    private string pointsPath;
    public Text pointsText;

    void Start()
    {
        scorePath = Application.dataPath + "/gameData/scores.txt";
        pointsPath = Application.dataPath + "/gameData/points.txt";
        Int32.TryParse(File.ReadAllText(pointsPath), out points);
        pointsText.text = "Current point balance : " + points;
    }

    void Update()
    {
        
    }
}
