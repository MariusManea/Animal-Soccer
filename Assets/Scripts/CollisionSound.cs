using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionSound : MonoBehaviour {

	public AudioSource[] sources;
	public int state;

	void Start () {
		sources = GetComponents<AudioSource> ();
		foreach (AudioSource audio in sources) {
			audio.volume = GameObject.Find ("Selected").GetComponent<Selected> ().SVolume;
		}
	}

	void Update () {
		if (transform.parent.GetComponent<Ball> ().bouncy)
			state = 1;
		else if (transform.parent.GetComponent<Ball> ().dead)
			state = 2;
		else
			state = 0;
	}
	/*void OnTriggerEnter2D(Collider2D other){
		if (other.gameObject.layer != 12 && other.gameObject.layer != 8 && other.gameObject.layer != 13)
			sources [state].Play ();
	}*/
}
