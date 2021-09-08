using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scoreboard : MonoBehaviour
{
    private static Scoreboard score;
    
    //config params
    [SerializeField] int pointsPerBlock = 50;
    [SerializeField] public Text scoreboard;

    //state variables
    [SerializeField] int gameScore = 0;

    //Singleton scoreboard
    private void Awake()
    {
        if (score == null)
        {
            score = this;
            GameObject.DontDestroyOnLoad(gameObject);
        }
        else
        {
            DestroyImmediate(gameObject);
        }
    }

    private void Start()
    {
        scoreboard.text = gameScore.ToString();
    }

    //track score
    public void AddToScore()
    {
        gameScore += pointsPerBlock;
        scoreboard.text = gameScore.ToString();
    }

    public void resetScore()
    {
        gameScore = 0;
        scoreboard.text = gameScore.ToString();
        Destroy(gameObject);
    }
}
