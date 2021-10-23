using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StatDisplay : MonoBehaviour
{

    public TextMeshProUGUI statDisplay;

    private void Awake()
    {
        int curHighScore = PlayerPrefs.GetInt("highscore");
        int mostDest = PlayerPrefs.GetInt("mostDestroyed");
        int bricksDestroyed = PlayerPrefs.GetInt("bricksDestroyed");

        statDisplay.text = curHighScore +"\n\n" + mostDest + "\n\n" + bricksDestroyed;
    }
}
