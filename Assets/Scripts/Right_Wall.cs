using UnityEngine;
using System.Collections;

public class Right_Wall : MonoBehaviour {
	public bool destroyed,used;
	public float time;
	public Transform top,bot;

	void Start () {
		destroyed = true;
		GameObject.Find ("Right_Brick_Wall").GetComponent<SpriteRenderer> ().enabled = false;
		GameObject.Find ("Right_Brick_Wall").GetComponent<BoxCollider2D> ().enabled = false;
	}

	void Update () {
		if (GameObject.Find ("Ball").GetComponent<Ball> ().right_wall) {
			destroyed = false;
			time = GameObject.Find ("Ball").GetComponent<Ball> ().time_wall;
		}
		if (destroyed) {
			GameObject.Find ("Right_Brick_Wall").GetComponent<SpriteRenderer> ().enabled = false;
			GameObject.Find ("Right_Brick_Wall").GetComponent<BoxCollider2D> ().enabled = false;
			used = false;
		} else {
			GameObject.Find ("Right_Brick_Wall").GetComponent<SpriteRenderer> ().enabled = true;
			GameObject.Find ("Right_Brick_Wall").GetComponent<BoxCollider2D> ().enabled = true;
			if(used){
				destroyed = true;
				GameObject.Find ("Ball").GetComponent<Ball> ().right_wall = false;
			}
			if(Time.time - time > 10){
				destroyed = true;
				GameObject.Find ("Ball").GetComponent<Ball> ().right_wall = false;
			}
		}
	}

	void OnCollisionEnter2D(Collision2D other){
		if (other.gameObject.name == "Ball")
			used = true;
	}

}
