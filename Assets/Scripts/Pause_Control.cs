using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause_Control : MonoBehaviour {

	public bool emit;
	public GameObject pause;
	public Sprite[] status;
	void Start () {
		
	}

	void Update () {
		if (emit) {
			GetComponent<AudioSource> ().Play ();
			emit = false;
		}
		if (this.gameObject.name == "Pause")
			GetComponent<SpriteRenderer> ().sprite = status [Mathf.FloorToInt (Time.timeScale)];
	}

	void OnMouseDown(){
		pause.GetComponent<Pause_Control> ().emit = true;
		GameObject.Find ("AreYouSure").GetComponent<SpriteRenderer> ().enabled = !GameObject.Find ("AreYouSure").GetComponent<SpriteRenderer> ().enabled;
		GameObject.Find ("Yes").GetComponent<SpriteRenderer> ().enabled = !GameObject.Find ("Yes").GetComponent<SpriteRenderer> ().enabled;
		GameObject.Find ("No").GetComponent<SpriteRenderer> ().enabled = !GameObject.Find ("No").GetComponent<SpriteRenderer> ().enabled;
		GameObject.Find ("Yes").GetComponent<BoxCollider2D> ().enabled = !GameObject.Find ("Yes").GetComponent<BoxCollider2D> ().enabled;
		GameObject.Find ("No").GetComponent<BoxCollider2D> ().enabled = !GameObject.Find ("No").GetComponent<BoxCollider2D> ().enabled;
		Time.timeScale = 1 - Time.timeScale;
	}
}
