using UnityEngine;
using System.Collections;

public class RightStriker : MonoBehaviour {
	public bool strike,kicked,able=true;
	public Transform striked;
	public float z,x,y;
	public AudioSource[] sources;
	public GameObject master,hitEffect;
	public ParticleSystem.ShapeModule shape;
	public ParticleSystem system;
	void Start () {
		master = GameObject.Find ("Selected");
		sources = GetComponents<AudioSource> ();
		foreach (AudioSource audio in sources){
			audio.volume = master.GetComponent<Selected> ().SVolume;
		}
	}
	void Update () {
		kicked = Physics2D.Linecast (this.transform.position, striked.position, 1 << LayerMask.NameToLayer ("Ball"));
		if (GameObject.Find ("Bomber").GetComponent<Bomber> ().right_bombed == false && GameObject.Find ("Ball").GetComponent<Ball> ().right_broke == false) {
			z = this.transform.rotation.z;
			if (able)
			if (Input.GetKeyDown (master.GetComponent<Selected>().Keys[7]) && Time.timeScale == 1) {
				sources [0].Play ();
				able = false;
				strike = true;
			}
			if (strike)
			if (Mathf.Abs (z) < 0.5f)
				this.transform.Rotate (Vector3.forward * 5);
			else {
				this.transform.Rotate (Vector3.forward * 0);
				strike = false;
			}
			else {
				if (Mathf.Abs (z) > 0.05f) {
					this.transform.Rotate (Vector3.back * 5);
					if (kicked) {
						GameObject.Find ("Ball").GetComponent<Ball> ().right = true;
						GameObject.Find ("Ball").GetComponent<Ball> ().left = false;
						if (Mathf.Abs (z) > 0.2f && Mathf.Abs (z) < 0.4f) { 
							x = 200 * Mathf.Abs (z);
							y = 150 * Mathf.Abs (z);
						} else if (Mathf.Abs (z) <= 0.2f) {
							x = 400 * (Mathf.Abs (z));
							y = 400 * Mathf.Abs (z);
						} else {
							x = 150 * (Mathf.Abs (z));
							y = 200 * Mathf.Abs (z);
						}
						GameObject.Find ("Ball").GetComponent<Rigidbody2D> ().AddForce (Vector2.left * x);
						GameObject.Find ("Ball").GetComponent<Rigidbody2D> ().AddForce (Vector2.up * y);
						sources [1].Play ();
						hitEffect = Instantiate (GameObject.Find ("HitEffect"), new Vector3 (GameObject.Find ("Ball").transform.position.x, GameObject.Find ("Ball").transform.position.y, -20f), GameObject.Find ("Ball").transform.rotation);
						system = hitEffect.GetComponent<ParticleSystem> ();
						shape = system.shape;
						shape.radius = GameObject.Find ("Ball").GetComponent<Ball> ().radius;
						hitEffect.GetComponent<ParticleSystem> ().Play ();
						Destroy (hitEffect, 1f);
					}
				}
				else
					able = true;
			}
		
			if (kicked == true && strike == true) {
				
				GameObject.Find ("Ball").GetComponent<Ball> ().right = true;
				GameObject.Find ("Ball").GetComponent<Ball> ().left = false;
				if (Mathf.Abs (z) > 0.2f && Mathf.Abs (z) < 0.4f) { 
					x = 1000 * Mathf.Abs (z);
					y = 750 * Mathf.Abs (z);
				} else if (Mathf.Abs (z) <= 0.2f) {
					x = 1000 * (0.5f - Mathf.Abs (z));
					y = 1000 * Mathf.Abs (z);
				} else {
					x = 750 * (0.5f - Mathf.Abs (z));
					y = 1000 * Mathf.Abs (z);
				}
				GameObject.Find ("Ball").GetComponent<Rigidbody2D> ().AddForce (Vector2.left * x);
				GameObject.Find ("Ball").GetComponent<Rigidbody2D> ().AddForce (Vector2.up * y);
				sources [1].Play ();
				hitEffect = Instantiate (GameObject.Find ("HitEffect"), new Vector3 (GameObject.Find ("Ball").transform.position.x, GameObject.Find ("Ball").transform.position.y, -20f), GameObject.Find ("Ball").transform.rotation);
				system = hitEffect.GetComponent<ParticleSystem> ();
				shape = system.shape;
				shape.radius = GameObject.Find ("Ball").GetComponent<Ball> ().radius;
				hitEffect.GetComponent<ParticleSystem> ().Play ();
				Destroy (hitEffect, 1f);
			}
		}
	}
}
