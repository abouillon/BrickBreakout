﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour {

    //config params
    [SerializeField] public static int breakableCount = 0;
    [SerializeField] AudioClip breakSound;
    [SerializeField] GameObject brickParticleFX;

    //cache references
    public Sprite[] hitSprites;
    private LevelManager levelManager;
    private Scoreboard addScore;

    //state variables
    private int timesHit;
    private bool isBreakable;

    // Use this for initialization
    void Start () {
        timesHit = 0;
        countBreakable();
        addScore = FindObjectOfType<Scoreboard>();
        levelManager = FindObjectOfType<LevelManager>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void countBreakable()
    {
        isBreakable = (this.tag == "Breakable");
        if (isBreakable)
        {
            breakableCount++;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (isBreakable)
        {
            HandleHits();
        }    
    }

    void HandleHits()
    {
        timesHit++;
        int maxHits = hitSprites.Length + 1;
        if (timesHit >= maxHits)
        {
            //StartCoroutine(RespawnBrick());
            breakableCount--;
            playBreakSFX();
            TriggerParticleFX();
            levelManager.BrickDestroyed();
        }
        else
        {
            LoadSprites();
        }
    }

    private void playBreakSFX()
    {
        AudioSource.PlayClipAtPoint(breakSound, Camera.main.transform.position, 0.45f);
        //Debug.Log("coords: " + gameObject.transform.position);
        Destroy(gameObject);
        addScore.AddToScore();
    }

    private void LoadSprites()
    {
        int spriteIndex = timesHit - 1;
        if (hitSprites[spriteIndex])
        {
            this.GetComponent<SpriteRenderer>().sprite = hitSprites[spriteIndex];
        }
    }

    private void TriggerParticleFX()
    {
        GameObject crumbles = Instantiate(brickParticleFX, transform.position, transform.rotation);
        Destroy(crumbles, 0.75f);
    }

    IEnumerator RespawnBrick()
    {
        gameObject.SetActive(false);
        yield return new UnityEngine.WaitForSeconds(3f);
        gameObject.SetActive(true);
        breakableCount++;

    }
}
