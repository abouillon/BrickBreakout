using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameState : MonoBehaviour
{
    private static GameState gameState;
    
    //config parameters
    [Range(0.1f, 10f)][SerializeField] float gameSpeed = 1f;
    [SerializeField] bool autoplay;

    //state variables
    private Paddle playPaddle;
    private Ball gameBall;
    private Scoreboard board;

    //Creates new play session and makes score persistent across levels
    private void Awake()
    {
        if(gameState == null)
        {
            gameState = this;
            GameObject.DontDestroyOnLoad(gameObject);
        } else
        {
            DestroyImmediate(gameObject);
        }
    }
    
    // Start is called before the first frame update
    void Start()
    {
        playPaddle = FindObjectOfType<Paddle>();
        gameBall = FindObjectOfType<Ball>();
        board = FindObjectOfType<Scoreboard>();
    }

    // Update is called once per frame
    void Update()
    {
        if(playPaddle == null)
        {
            playPaddle = FindObjectOfType<Paddle>();
        }

        Time.timeScale = gameSpeed;
        if(Input.GetAxis("Mouse ScrollWheel") < 0f && gameBall.hasStarted)
        {
            playPaddle.RotateLeft();
        }
        if(Input.GetAxis("Mouse ScrollWheel") > 0f && gameBall.hasStarted)
        {
            playPaddle.RotateRight();
        }
        if (Input.GetKey(KeyCode.Mouse2) && gameBall.hasStarted)
        {
            playPaddle.ReturnMiddle();
        }

    }

    public void ResetState()
    {
        Destroy(gameObject);
        board.resetScore();
    }

    public bool EnableAutoplay()
    {
        return autoplay;
    }
}
