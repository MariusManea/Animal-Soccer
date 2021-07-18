using UnityEngine;
using System.Collections;

public class SpeedUp : MonoBehaviour {

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
			ball.GetComponent<Ball> ().speedUp = true;
			ball.GetComponent<Ball> ().time_SpeedUp = Time.time;
			GameObject.Find ("Spawner").GetComponent<PowerUpSpawner> ().powerS--;
			Destroy (this.gameObject);
		}
	}
	void OnTriggerStay2D(Collider2D other){
		if (other.name == "Ball") {
			GameObject.Find ("PowerUpPlayer").GetComponent<PowerUpPlayer> ().sources [7].Play ();
			triggered = true;
		}
	}
	void OnTriggerExit2D(Collider2D other){
		if (other.name == "Ball")
			triggered = false;
	}
}
