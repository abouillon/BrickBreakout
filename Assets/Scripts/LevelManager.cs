using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {

    //cached references
    private GameState state;
    private Scoreboard score;

    public void LoadLevel(string name)
    {
        state = FindObjectOfType<GameState>();
        if(name == "Lose" || name == "Win")
        {

            print("Loading Win/Lose");
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
