using UnityEngine;
using System.Collections;

public class Brick : MonoBehaviour {

	public int maxHits;
	public Sprite[] hitSprites;
	
	private LevelManager levelManager;
	private int timesHit;
	 
	// Use this for initialization
	void Start () {
		levelManager = FindObjectOfType<LevelManager>();
		timesHit = 0;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnCollisionEnter2D (Collision2D collision) {
		timesHit++;
	}
	
	void OnCollisionExit2D (Collision2D collision) {
		if (timesHit >= maxHits) {
			Destroy(gameObject);
		} else {
			loadSprites();
		} 
	}

	void loadSprites () {
		int spriteIndex = timesHit - 1;
		this.GetComponent<SpriteRenderer>().sprite = hitSprites[spriteIndex];
	}
	
	// TODO Remove this once we can actually win
	void SimulateWin() {
		levelManager.LoadNextLevel();
	}
}
