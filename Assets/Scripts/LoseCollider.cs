using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoseCollider : MonoBehaviour {

    private LevelManager levelManager;

    private void Start()
    {
        levelManager = FindObjectOfType<LevelManager>();
        print("Start Called");
        print(levelManager);
    }

    private void OnTriggerEnter2D(Collider2D trigger)
    {
        print("Trigger Collider");
        levelManager.LoadLevel("Lose");
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        print("Non-Trigger Collider");
    }
}
