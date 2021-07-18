using UnityEngine;
using System.Collections;

public class NoButton : MonoBehaviour {
	public Sprite[] no;

	void OnMouseEnter(){
		GetComponent<SpriteRenderer> ().sprite = no [1];
	}
	void OnMouseExit(){
		GetComponent<SpriteRenderer> ().sprite = no [0];
	}

	void OnMouseDown(){
		GetComponent<AudioSource> ().Play ();
		GameObject.Find("AreYouSure").GetComponent<SpriteRenderer>().enabled = !GameObject.Find("AreYouSure").GetComponent<SpriteRenderer>().enabled;
		GameObject.Find("Yes").GetComponent<SpriteRenderer>().enabled = !GameObject.Find("Yes").GetComponent<SpriteRenderer>().enabled;
		GameObject.Find("No").GetComponent<SpriteRenderer>().enabled = !GameObject.Find("No").GetComponent<SpriteRenderer>().enabled;
		GameObject.Find("Yes").GetComponent<BoxCollider2D>().enabled = !GameObject.Find("Yes").GetComponent<BoxCollider2D>().enabled;
		GameObject.Find("No").GetComponent<BoxCollider2D>().enabled = !GameObject.Find("No").GetComponent<BoxCollider2D>().enabled;
		Time.timeScale = 1 - Time.timeScale;
	}
}
