using UnityEngine;
using System.Collections;

public class BombExplosion : MonoBehaviour {
	public bool explosion,check;
	public Animator anim;
	public Transform ground;
	public GameObject ball,bomber;

	void Start () {
		anim = GetComponent<Animator> ();
		ball = GameObject.Find ("Ball");
		ground = this.transform.GetChild (0);
		bomber = GameObject.Find ("Bomber");
	}

	void Update () {
		explosion = Physics2D.Linecast(this.transform.position, ground.position, 1<<LayerMask.NameToLayer("Ground"));
		if(Physics2D.Linecast(this.transform.position, ground.position, 1<<LayerMask.NameToLayer("LeftPlayer"))) explosion = true;
		if(Physics2D.Linecast(this.transform.position, ground.position, 1<<LayerMask.NameToLayer("RightPlayer"))) explosion = true;
		if(explosion){ 
			anim.SetBool ("Boom", true);
			if (!check) {
				if (Physics2D.CircleCast (this.transform.position, 0.595f, Vector2.down, 0.595f, 1 << LayerMask.NameToLayer ("LeftPlayer"))) {
					bomber.GetComponent<Bomber> ().left_bombed = true;
				}
				if (Physics2D.CircleCast (this.transform.position, 0.595f, Vector2.down, 0.595f, 1 << LayerMask.NameToLayer ("RightPlayer"))) {
					bomber.GetComponent<Bomber> ().right_bombed = true;
				}
				check = true;
				GetComponent<AudioSource> ().Play ();
			}
			GetComponent<Rigidbody2D> ().isKinematic = true;
			GetComponent<Rigidbody2D> ().Sleep ();
			Destroy(this.gameObject,0.5f);
		}
	}
	void OnDestroy(){
		if(bomber)bomber.GetComponent<Bomber> ().spawn = false;
		if(ball)ball.GetComponent<Ball> ().Nbomb -=1;
	}
}
