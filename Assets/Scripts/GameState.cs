using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameState : MonoBehaviour
{
    private static GameState gameState;
    
    //config parameters
    [Range(0.1f, 10f)][SerializeField] float gameSpeed = 1f;
    [SerializeField] int pointsPerBlock = 50;
    [SerializeField] public Text scoreboard;

    //state variables
    [SerializeField] int gameScore = 0;

    //Creates new play session and makes score persistent across levels
    private void Awake()
    {
        Debug.Log("State Instance " + GetInstanceID());
        if(gameState == null)
        {
            gameState = this;
            GameObject.DontDestroyOnLoad(gameObject);
        } else
        {
            DestroyImmediate(gameObject);
            Debug.Log("Removed Duplicate State");
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

    public void ResetState()
    {
        Destroy(gameObject);
    }
}
