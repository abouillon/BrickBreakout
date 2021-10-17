using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {

    //cached references
    private GameState state;

    //state variables
    private string curScn;

    private void Awake()
    {
        curScn = SceneManager.GetActiveScene().name;

        //setup initial stats for saving
        if (curScn.Equals("Start"))
        {
            if (!PlayerPrefs.HasKey("highscore") && !PlayerPrefs.HasKey("bricksDestroyed"))
            {
                PlayerPrefs.SetInt("highscore", 0);
                PlayerPrefs.SetInt("bricksDestroyed", 0);
                PlayerPrefs.Save();
            }
        }
    }

    public void LoadLevel(string name)
    {
        state = FindObjectOfType<GameState>();
        if(name == "Lose")
        {
            Brick.breakableCount = 0;
            SceneManager.LoadScene(name);
            state.ResetState();
        } else
        {
            SceneManager.LoadScene(name);
        }
    }

    public void QuitRequest()
    {
        Application.Quit();
    }

    public void BrickDestroyed()
    {
        if (Brick.breakableCount <= 0)
        {
            //TODO track bricks broken here
        }
    }

}
