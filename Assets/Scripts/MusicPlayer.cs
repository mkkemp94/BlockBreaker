using UnityEngine;
using System.Collections;

public class MusicPlayer : MonoBehaviour {
	static MusicPlayer instance = null;
	
	// Use this for initialization
	void Start () {
		if (instance == null) {
			GameObject.DontDestroyOnLoad(gameObject);
			instance = this;
		} else {
			Destroy(gameObject);
			print ("Self-destructing duplicate music player!");
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
