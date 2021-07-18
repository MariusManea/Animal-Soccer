using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnablePowerUpsButton : MonoBehaviour {

	public GameObject master;
	void Start () {
		master = GameObject.Find ("Selected");
	}

	void Update () {
		if(master.GetComponent<Selected>().powerups)GetComponent<SpriteRenderer>().enabled = true;
			else GetComponent<SpriteRenderer>().enabled = false;
	}

	void OnMouseDown()
	{
		master.GetComponent<Selected> ().powerups = !master.GetComponent<Selected> ().powerups;
		GetComponent<AudioSource> ().Play ();
	}
}
