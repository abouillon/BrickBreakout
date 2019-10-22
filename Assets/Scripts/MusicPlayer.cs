using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour {

    private static MusicPlayer instance;

    private void Awake()
    {
        Debug.Log("Music Player " + GetInstanceID());
        if (instance == null)
        {
            instance = this;
            GameObject.DontDestroyOnLoad(gameObject);
        }
        else
        {
            DestroyImmediate(gameObject);
            print("Duplicate Player Destroyed");
        }
    }

    // Use this for initialization
    void Start () {
        Debug.Log("Music Player " + GetInstanceID());
        
	}
}
