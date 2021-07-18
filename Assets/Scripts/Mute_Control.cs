using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mute_Control : MonoBehaviour {

	public AudioSource[] sources;
	public AudioSource music;
	public GameObject gMusic;
	public Sprite[] status;
	public int actualStatus;
	public Selected master;
	public void Start () {
		gMusic = GameObject.Find ("Score");
		master = GameObject.Find ("Selected").GetComponent<Selected> ();
		sources = GameObject.FindObjectsOfType <AudioSource> () as AudioSource[];
		music = gMusic.GetComponent<AudioSource> ();
		actualStatus = master.mute;
		if (actualStatus == 1) {
			music.mute = true;
			foreach (AudioSource audio in sources)
				if(audio&&audio!=music)audio.mute = true;
			GetComponent<SpriteRenderer> ().sprite = status [actualStatus];
		}
	}

	void Update () {
		if (Input.GetKeyDown (master.Keys [9])) {
			GetComponent<AudioSource> ().Play ();
			music.mute = !music.mute;
			foreach (AudioSource audio in sources)
				if(audio&&audio!=music)audio.mute = !audio.mute;
			actualStatus = 1 - actualStatus;
			master.mute = actualStatus;
			GetComponent<SpriteRenderer> ().sprite = status [actualStatus];
		}
	}
	void OnMouseDown(){
		music.mute = !music.mute;
		foreach (AudioSource audio in sources)
			if(audio&&audio!=music)audio.mute = !audio.mute;
		actualStatus = 1 - actualStatus;
		master.mute = actualStatus;
		GetComponent<SpriteRenderer> ().sprite = status [actualStatus];
		if (actualStatus == 0)
			GetComponent<AudioSource> ().Play ();
	}
}
