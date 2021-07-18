using UnityEngine;
using System.Collections;

public class RightPlayerMovement : MonoBehaviour {
	public int X;
	public bool grounded, jumped=false,collide;
	public Transform ground;
	public Vector3 v,si,sg,ss;
	public float time_grow,time_shrink,time_freeze,time_SpeedUp,time_slow,time_broke;
	public float speed;
	private Animator anim,anim2;
	public AudioSource[] sources;
	public Selected master;
	public GameObject hitEffect;
	public ParticleSystem.ShapeModule shape;
	public ParticleSystem system;
	void Start () {
		master = GameObject.Find ("Selected").GetComponent<Selected> ();
		anim = GetComponent<Animator> ();
		anim2 = GameObject.Find ("RightArm").GetComponent<Animator> ();
		ground = this.transform.GetChild (2);
		X = 8;
		si.x = -1.5f;
		si.y = 1.75f;
		si.z = 1f;
		sg.x = -2.1f;
		sg.y = 2.35f;
		sg.z = 1f;
		ss.x = -1f;
		ss.y = 1.25f;
		ss.z = 1f;
		speed = 6f;
		GetComponent<CapsuleCollider2D> ().sharedMaterial.friction = 0;
		sources = GetComponents<AudioSource> ();
		foreach (AudioSource audio in sources) {
			audio.volume = GameObject.Find ("Selected").GetComponent<Selected> ().SVolume;
		}
	}
	
	void Update () {
		anim2 = GameObject.Find ("RightArm").GetComponent<Animator> ();
		if (GameObject.Find ("Ball").GetComponent<Ball> ().right_grow) {
			if (GameObject.Find ("Ball").GetComponent<Ball> ().right_shrink)
				GameObject.Find ("Ball").GetComponent<Ball> ().right_shrink = false;
			if (Time.time - time_grow <= 10)
				this.transform.localScale = sg;
			else{
				this.transform.localScale = si;
				GameObject.Find ("Ball").GetComponent<Ball> ().right_grow = false;
			}
		}
		if (GameObject.Find ("Ball").GetComponent<Ball> ().right_shrink) {
			if (GameObject.Find ("Ball").GetComponent<Ball> ().right_grow)
				GameObject.Find ("Ball").GetComponent<Ball> ().right_grow = false;
			if (Time.time - time_shrink <= 10)
				this.transform.localScale = ss;
			else{
				this.transform.localScale = si;
				GameObject.Find ("Ball").GetComponent<Ball> ().right_shrink = false;
			}
		}
		if (GameObject.Find ("Ball").GetComponent<Ball> ().right_freeze) {
			if (Time.time - time_freeze <= 10) {
				speed = 0f;
				anim.SetBool ("Freeze", true);
				anim2.SetBool ("Froze", true);
				anim2.SetBool ("Broken", false);
			} else {
				speed = 6f;
				anim.SetBool ("Freeze", false);
				anim2.SetBool ("Froze", false);
				GameObject.Find ("Ball").GetComponent<Ball> ().right_freeze = false;
			}
		}
		if (GameObject.Find ("Ball").GetComponent<Ball> ().right_broke) {
			if (Time.time - time_broke <= 10) {
				anim2.SetBool ("Broken", true);
				GameObject.Find ("RightHand").GetComponent<SpriteRenderer>().enabled = false;
			} else {
				anim2.SetBool ("Broken", false);
				GameObject.Find ("RightHand").GetComponent<SpriteRenderer>().enabled = true;
				GameObject.Find ("Ball").GetComponent<Ball> ().right_broke = false;
			}
		}
		if (GameObject.Find ("Ball").GetComponent<Ball> ().right_SpeedUp && !GameObject.Find ("Ball").GetComponent<Ball> ().right_freeze) {
			if (GameObject.Find ("Ball").GetComponent<Ball> ().right_slow)
				GameObject.Find ("Ball").GetComponent<Ball> ().right_slow = false;
			if (Time.time - time_SpeedUp <= 10) {
				speed = 10f;
			} else {
				speed = 6f;
				GameObject.Find ("Ball").GetComponent<Ball> ().right_SpeedUp = false;
			}
		}
		if (GameObject.Find ("Ball").GetComponent<Ball> ().right_slow && !GameObject.Find ("Ball").GetComponent<Ball> ().right_freeze) {
			if (GameObject.Find ("Ball").GetComponent<Ball> ().right_SpeedUp)
				GameObject.Find ("Ball").GetComponent<Ball> ().right_SpeedUp = false;
			if (Time.time - time_slow <= 10) {
				speed = 3f;
			} else {
				speed = 6f;
				GameObject.Find ("Ball").GetComponent<Ball> ().right_slow = false;
			}
		}
		Debug.DrawLine (new Vector2 (ground.position.x, this.transform.position.y), ground.position);
		if (Physics2D.Linecast (new Vector2(ground.position.x,this.transform.position.y), ground.position, 1 << LayerMask.NameToLayer ("Ground")) || Physics2D.Linecast (new Vector2(ground.position.x,this.transform.position.y), ground.position, 1 << LayerMask.NameToLayer ("LeftPlayer")) || Physics2D.Linecast (new Vector2(ground.position.x,this.transform.position.y), ground.position, 1 << LayerMask.NameToLayer ("Ball")) || Physics2D.Linecast (new Vector2(ground.position.x,this.transform.position.y), ground.position, 1 << LayerMask.NameToLayer ("Default")))
			grounded = true;
		else
			grounded = false;
		if (grounded == true) {
			jumped = false;
			anim.SetBool ("Grounded", true);
		} else
			anim.SetBool ("Grounded", false);
		if (GameObject.Find ("Bomber").GetComponent<Bomber> ().right_bombed == false) {
			if (Input.GetKey (master.Keys[5]) && !Input.GetKey (master.Keys[4])) {
				anim.SetBool ("Move", true);
				v = GetComponent<Rigidbody2D> ().velocity;
				v.x = speed;
				GetComponent<Rigidbody2D> ().velocity = v;
			} else {
				if (Input.GetKey (master.Keys[4]) && !Input.GetKey (master.Keys[5])) {
					anim.SetBool ("Move", true);
					v = GetComponent<Rigidbody2D> ().velocity;
					v.x = -speed;
					GetComponent<Rigidbody2D> ().velocity = v;
				} else if (grounded == true) {
					anim.SetBool ("Move", false);
					v = GetComponent<Rigidbody2D> ().velocity;
					v.x = 0f;
					GetComponent<Rigidbody2D> ().velocity = v;
				}
			}
			if (Input.GetKeyDown (master.Keys[6]) && grounded && !jumped) { 
				if (GameObject.Find ("Ball").GetComponent<Ball> ().right_grow) {
					sources [1].Play ();
				}
				else {
					if (GameObject.Find ("Ball").GetComponent<Ball> ().right_shrink) {
						sources [2].Play ();
					} else {
						sources [0].Play ();
					}
				}
				jumped = true;
				GetComponent<Rigidbody2D> ().AddForce (Vector2.up * 45000f);
			}
		}else {
			v.x = 0f;
			v.y = 0f;
			GetComponent<CapsuleCollider2D> ().sharedMaterial.friction = 0.71f;
			GetComponent<CapsuleCollider2D> ().enabled = false;
			GetComponent<CapsuleCollider2D> ().enabled = true;
			GetComponent<Rigidbody2D> ().velocity = v;
			anim.SetBool ("Blown", true);
			anim2.SetBool ("Blown", true);
			GetComponent<RightPlayerMovement> ().enabled = false;
		}
	}

	void OnCollisionEnter2D(Collision2D other){
		if (other.gameObject.name == "Ball") {
			/*GameObject.Find ("SmashSound").GetComponent<CollisionSound> ().sources [GameObject.Find ("SmashSound").GetComponent<CollisionSound> ().state].volume = GameObject.Find ("Selected").GetComponent<Selected> ().SVolume * other.relativeVelocity.magnitude / 50;
			collide = true;
			if (collide) {
				if (!GameObject.Find ("LEFT").GetComponent<LeftPlayerMovement> ().collide) {
					hitEffect = Instantiate (GameObject.Find ("HitEffect"), new Vector3 (GameObject.Find ("Ball").transform.position.x, GameObject.Find ("Ball").transform.position.y, -20f), this.transform.rotation);
					system = hitEffect.GetComponent<ParticleSystem> ();
					shape = system.shape;
					shape.radius = GameObject.Find ("Ball").GetComponent<Ball> ().radius;
					hitEffect.GetComponent<ParticleSystem> ().Play ();
					Destroy (hitEffect, 1f);
					GameObject.Find ("SmashSound").GetComponent<CollisionSound> ().sources [GameObject.Find ("SmashSound").GetComponent<CollisionSound> ().state].Play ();
				} else if (other.relativeVelocity.magnitude > 7) {
					GameObject.Find ("SmashSound").GetComponent<CollisionSound> ().sources [GameObject.Find ("SmashSound").GetComponent<CollisionSound> ().state].Play ();
					hitEffect = Instantiate (GameObject.Find ("HitEffect"), new Vector3 (GameObject.Find ("Ball").transform.position.x, GameObject.Find ("Ball").transform.position.y, -20f), this.transform.rotation);
					system = hitEffect.GetComponent<ParticleSystem> ();
					shape = system.shape;
					shape.radius = GameObject.Find ("Ball").GetComponent<Ball> ().radius;
					hitEffect.GetComponent<ParticleSystem> ().Play ();
					Destroy (hitEffect, 1f);
				}
			}*/
			GameObject.Find ("Ball").GetComponent<Ball> ().left = false;
			GameObject.Find ("Ball").GetComponent<Ball> ().right = true;
		}
	}
	/*void OnCollisionExit2D(Collision2D other){
		if (other.gameObject.name == "Ball")
			collide = false;
	}*/
}
