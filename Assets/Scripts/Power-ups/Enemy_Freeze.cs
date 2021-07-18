using UnityEngine;
using System.Collections;

public class Enemy_Freeze : MonoBehaviour {

	public bool triggered;
	public Vector3 V;
	public float spawn;
	public Animator anim_writer;
	public GameObject ball;
	void Awake () {
		anim_writer = GameObject.Find ("Writing").GetComponent<Animator> ();
		ball = GameObject.Find ("Ball");
	}
	void Start () {

	}


	void Update () {
		if (Time.time - spawn > 15) {
			GameObject.Find ("Spawner").GetComponent<PowerUpSpawner> ().powerS--;
			Destroy (this.gameObject);
		}
		if (triggered) {
			anim_writer.SetInteger ("Writing", 1);
			ball.GetComponent<Ball> ().freeze = true;
			ball.GetComponent<Ball> ().time_freeze = Time.time;
			ball.GetComponent<Ball> ().time_time = Time.time;
			GameObject.Find ("Spawner").GetComponent<PowerUpSpawner> ().powerS--;
			Destroy (this.gameObject);
		}
	}
	void OnTriggerStay2D(Collider2D other){
		if (other.name == "Ball") {
			GameObject.Find ("PowerUpPlayer").GetComponent<PowerUpPlayer> ().sources [3].Play ();
			triggered = true;
		}
	}
	void OnTriggerExit2D(Collider2D other){
		if (other.name == "Ball")
			triggered = false;
	}
}
