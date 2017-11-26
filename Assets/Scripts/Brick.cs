using UnityEngine;
using System.Collections;

public class Brick : MonoBehaviour {

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
		timesHit++;
	}
	
	void OnCollisionExit2D (Collision2D collision) {
		if (isBreakable) {
			HandleHits();
		}
	}
	
	void HandleHits() {
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
		if (hitSprites[spriteIndex]) {
			this.GetComponent<SpriteRenderer>().sprite = hitSprites[spriteIndex];
		}
	}
	
	// TODO Remove this once we can actually win
	void SimulateWin() {
		levelManager.LoadNextLevel();
	}
}
