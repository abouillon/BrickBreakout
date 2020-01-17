using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameState : MonoBehaviour
{
    //config parameters
    [Range(0.1f, 10f)][SerializeField] float gameSpeed = 1f;
    [SerializeField] int pointsPerBlock = 50;
    [SerializeField] public Text scoreboard;

    //state variables
    [SerializeField] int gameScore = 0;

    private void Awake()
    {
        int instanceCount = FindObjectsOfType<GameState>().Length;
        if(instanceCount > 1)
        {
            gameObject.setActive(false);
            Destroy(gameObject);
        } else
        {
            DontDestroyOnLoad(gameObject);
        }
    }
    
    // Start is called before the first frame update
    void Start()
    {
        scoreboard.text = gameScore.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        Time.timeScale = gameSpeed;
    }

    //track score
    public void AddToScore()
    {
        gameScore += pointsPerBlock;
        scoreboard.text = gameScore.ToString();
    }
}
