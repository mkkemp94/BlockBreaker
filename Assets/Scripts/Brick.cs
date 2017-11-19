using UnityEngine;
using System.Collections;

public class Brick : MonoBehaviour {

	public int maxHits;
	
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
		}
	}
	
	// TODO Remove this once we can actually win
	void SimulateWin() {
		levelManager.LoadNextLevel();
	}
}
