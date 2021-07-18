using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioSettings : MonoBehaviour {
	public GameObject master;
	public int source;

	void Start () {
		master = GameObject.Find ("Selected");
	}

	void Update () {
		if(source == 1)
			GetComponent<AudioSource> ().volume = master.GetComponent<Selected> ().SVolume;
		else 
			GetComponent<AudioSource> ().volume = master.GetComponent<Selected> ().MVolume;
	}
}
