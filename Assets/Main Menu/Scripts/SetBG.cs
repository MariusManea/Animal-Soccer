using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetBG : MonoBehaviour {

	public Sprite[] sprites;
	public Sprite BG;
	public GameObject master,display;
	public int nr;

	void Start () {
		master = GameObject.Find ("Selected");
		display = GameObject.Find ("Display");
	}

	void Update () {
		if (master.GetComponent<Selected> ().BackGround == nr) {
			GetComponent<SpriteRenderer> ().sprite = sprites [1];
			display.GetComponent<SpriteRenderer> ().sprite = BG;
		}
		else
			GetComponent<SpriteRenderer> ().sprite = sprites [0];
	}

	void OnMouseDown(){
		GetComponent<AudioSource> ().Play ();
			master.GetComponent<Selected> ().BackGround = nr;
	}
}
