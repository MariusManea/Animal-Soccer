using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpPlayer : MonoBehaviour {
	
	public GameObject master;
	public AudioSource[] sources;

	void Start () {
		master = GameObject.Find ("Selected");
		sources = GetComponents<AudioSource> ();
		foreach (AudioSource audio in sources){
			audio.volume = master.GetComponent<Selected> ().SVolume;
		}
	}

	void Update () {
		
	}
}
