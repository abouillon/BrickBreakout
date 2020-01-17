﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {

    private GameState state;

    public void LoadLevel(string name)
    {
        state = FindObjectOfType<GameState>();
        Debug.Log("Level Load Requested for " + name);
        if(name == "Lose" || name == "Win")
        {
            Brick.breakableCount = 0;
            state.ResetState();
        }
        SceneManager.LoadScene(name);
    }

    public void QuitRequest()
    {
        Debug.Log("Quit Request initiated");
        Application.Quit();
    }

    public void LoadNextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void BrickDestroyed()
    {
        if (Brick.breakableCount <= 0)
        {
            LoadNextLevel();
        }
    }

}
