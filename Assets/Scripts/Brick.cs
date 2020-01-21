using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour {

    [SerializeField] public static int breakableCount = 0;
    [SerializeField] AudioClip breakSound;
    [SerializeField] GameObject brickParticleFX;

    public Sprite[] hitSprites;
    private int timesHit;
    private LevelManager levelManager;
    private bool isBreakable;
    private GameState addScore;

    // Use this for initialization
    void Start () {
        timesHit = 0;
        isBreakable = (this.tag == "Breakable");
        if (isBreakable)
        {
            breakableCount++;
        }
        addScore = FindObjectOfType<GameState>();
        levelManager = FindObjectOfType<LevelManager>();
	}
	
	// Update is called once per frame
	void Update () {
		
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
        AudioSource.PlayClipAtPoint(breakSound, Camera.main.transform.position);
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
}
