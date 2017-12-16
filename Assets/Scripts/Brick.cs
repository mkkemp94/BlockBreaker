using UnityEngine;
using System.Collections;

public class Brick : MonoBehaviour {

	public AudioClip crack;
	public static int breakableCount = 0;
	public Sprite[] hitSprites;
	
	private LevelManager levelManager;
	private int timesHit;
	private bool isBreakable;
	 
	// Use this for initialization
	void Start () {
		isBreakable = (this.tag == "Breakable");
		if (isBreakable) {
			breakableCount++;
		}
		
		timesHit = 0;
		levelManager = FindObjectOfType<LevelManager>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnCollisionEnter2D (Collision2D collision) {
		
		AudioSource.PlayClipAtPoint(crack, transform.position);
		if (isBreakable) {
			HandleHits();
		}
	}
	
	void OnCollisionExit2D (Collision2D collision) {
		
	}
	
	void HandleHits() {
		timesHit++;
		int maxHits = hitSprites.Length + 1;
		if (timesHit >= maxHits) {
			breakableCount--;
			levelManager.BrickDestroyed();
			Destroy(gameObject);
		} else {
			loadSprites();
		} 
	}

	void loadSprites () {
		int spriteIndex = timesHit - 1;
		
		// There is a sprite here
		if (hitSprites[spriteIndex] != null) {
			this.GetComponent<SpriteRenderer>().sprite = hitSprites[spriteIndex];
		} 
		// Sprite is missing
		else {
			Debug.LogError("Brick sprite missing!");
		}
	}
	
	// TODO Remove this once we can actually win
	void SimulateWin() {
		levelManager.LoadNextLevel();
	}
}
