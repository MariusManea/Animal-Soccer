using UnityEngine;
using System.Collections;

public class SuperCannon : MonoBehaviour {

	public bool rotate = true, choose,cannon;
	public float time,stop;
	public Vector3 dir,i,poz;
	public GameObject ball;
	void Start () {
		poz.y = -1;
		poz.z = 1;
		ball = GameObject.Find ("Ball");
		GameObject.Find ("Cannon").GetComponent<SpriteRenderer> ().enabled = false;
		GameObject.Find ("LeftWall").GetComponent<BoxCollider2D> ().enabled = false;
		GameObject.Find ("RightWall").GetComponent<BoxCollider2D> ().enabled = false;
		GameObject.Find ("XLeftWall").GetComponent<BoxCollider2D> ().enabled = false;
		GameObject.Find ("XRightWall").GetComponent<BoxCollider2D> ().enabled = false;
		GameObject.Find ("Platform").GetComponent<BoxCollider2D> ().enabled = false;
		GameObject.Find ("CannonEnd").GetComponent<BoxCollider2D> ().enabled = false;
		GameObject.Find ("Stand").GetComponent<SpriteRenderer> ().enabled = false;
		GameObject.Find ("Stand").GetComponent<BoxCollider2D> ().enabled = false;
	}

	void Update () {
		if (cannon) {
			ball.transform.SetParent (this.transform);
			ball.transform.localPosition = poz;
			ball.GetComponent<SpriteRenderer> ().enabled = false;
			stop = Random.Range (0, 401) / 1000f;
			if (!choose) {
				if (rotate) {
					this.transform.RotateAround (this.transform.position, Vector3.forward, 5f);
					if (Mathf.Abs (60f - this.transform.rotation.eulerAngles.z) < 1f)
						rotate = false;
				} else {
					this.transform.RotateAround (this.transform.position, Vector3.back, 5f);
					if (Mathf.Abs (60f - 360f + this.transform.rotation.eulerAngles.z) < 1f)
						rotate = true;
				}
			}
			if (Time.time - time - stop > 2.9f)
				choose = true;
			if (choose) {
				GetComponent<AudioSource> ().Play ();
				cannon = false;
				GameObject.Find ("Platform").GetComponent<BoxCollider2D> ().enabled = false;
				//dir.x = Mathf.Sin(this.transform.rotation.z);
				//dir.y = -Mathf.Cos (this.transform.rotation.z);
				GameObject.Find ("SmashSound").GetComponent<CircleCollider2D> ().enabled = true;
				ball.transform.localPosition = poz;
				dir = this.transform.position - ball.transform.position;
				ball.transform.SetParent (null);
				ball.GetComponent<SpriteRenderer> ().enabled = true;
				ball.GetComponent<Rigidbody2D> ().AddForce (dir * 5000f);
				choose = false;
			}
			if (Time.time - time - stop > 3.2f)
				GameObject.Find ("Platform").GetComponent<BoxCollider2D> ().enabled = true;
		} else if (Time.time - time > 5) {
			this.transform.rotation = Quaternion.Euler (i);
			GameObject.Find ("Cannon").GetComponent<SpriteRenderer> ().enabled = false;
			GameObject.Find ("LeftWall").GetComponent<BoxCollider2D> ().enabled = false;
			GameObject.Find ("RightWall").GetComponent<BoxCollider2D> ().enabled = false;
			GameObject.Find ("XLeftWall").GetComponent<BoxCollider2D> ().enabled = false;
			GameObject.Find ("XRightWall").GetComponent<BoxCollider2D> ().enabled = false;
			GameObject.Find ("Platform").GetComponent<BoxCollider2D> ().enabled = false;
			GameObject.Find ("CannonEnd").GetComponent<BoxCollider2D> ().enabled = false;
			GameObject.Find ("Stand").GetComponent<SpriteRenderer> ().enabled = false;
			GameObject.Find ("Stand").GetComponent<BoxCollider2D> ().enabled = false;
		}
	}
}
