using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class YesButton : MonoBehaviour {
	public Sprite[] yes;
	public float time;
	public bool clicked;

	void Start(){
		clicked = false;
	}

	void OnMouseEnter(){
		GetComponent<SpriteRenderer> ().sprite = yes [1];
	}
	void OnMouseExit(){
		GetComponent<SpriteRenderer> ().sprite = yes [0];
	}
	void OnMouseDown(){
		GetComponent<AudioSource> ().Play ();
		time = Time.realtimeSinceStartup;
		clicked = true;
	}
	void Update(){
		if (Time.realtimeSinceStartup - time > 0.15f&&clicked) {
			GameObject.Find("AreYouSure").GetComponent<SpriteRenderer>().enabled = !GameObject.Find("AreYouSure").GetComponent<SpriteRenderer>().enabled;
			GameObject.Find("Yes").GetComponent<SpriteRenderer>().enabled = !GameObject.Find("Yes").GetComponent<SpriteRenderer>().enabled;
			GameObject.Find("No").GetComponent<SpriteRenderer>().enabled = !GameObject.Find("No").GetComponent<SpriteRenderer>().enabled;
			GameObject.Find("Yes").GetComponent<BoxCollider2D>().enabled = !GameObject.Find("Yes").GetComponent<BoxCollider2D>().enabled;
			GameObject.Find("No").GetComponent<BoxCollider2D>().enabled = !GameObject.Find("No").GetComponent<BoxCollider2D>().enabled;
			Time.timeScale = 1;
			//Application.LoadLevel (Application.loadedLevel - 1);
			SceneManager.LoadScene(0,LoadSceneMode.Single);
		}
	}
}
