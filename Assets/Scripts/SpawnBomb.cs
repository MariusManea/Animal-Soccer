using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class SpawnBomb : MonoBehaviour {
	
	public Vector3 v,i;
	public float time,time_restart;
	public bool spawn,explosion;
	public Transform groundedEnd;
	public bool left_bombed, right_bombed,restart;
	private Animator anim;

	void Start () {
		i.x = -5f;
		i.y = 15f;
		i.z = -4f;
		anim = GameObject.Find ("Bomb").GetComponent <Animator> ();
		v.y = 12;
		v.z = 2;
		left_bombed = false;
		right_bombed = false;
	}

	void Update () {
		if(Time.time - GameObject.Find("Bomb").GetComponent<SpawnBomb>().time> 0.5f)GameObject.Find ("Bomb").transform.position = i;
		if (GameObject.Find ("Ball").GetComponent<Ball> ().Nbomb > 0 && !spawn &&Time.time - GameObject.Find("Bomb").GetComponent<SpawnBomb>().time> 0.5f) {
			spawn = true;
			GameObject.Instantiate(gameObject);
			v.x=Random.Range(-9.5f, 10f);
			GameObject.Find ("Bomb(Clone)").transform.position = v;
			GameObject.Find ("Bomb(Clone)").GetComponent<SpriteRenderer> ().enabled = true;
			GameObject.Find ("Bomb(Clone)").GetComponent<Animator> ().enabled = true;
			GameObject.Find ("Bomb(Clone)").GetComponent<Rigidbody2D>().isKinematic = false;
		}
		if (spawn) {
			explosion = Physics2D.Linecast(this.transform.position, groundedEnd.position, 1<<LayerMask.NameToLayer("Ground"));
			if(Physics2D.Linecast(this.transform.position, groundedEnd.position, 1<<LayerMask.NameToLayer("LeftPlayer"))) explosion = true;
			if(Physics2D.Linecast(this.transform.position, groundedEnd.position, 1<<LayerMask.NameToLayer("RightPlayer"))) explosion = true;
			if(explosion){ 
				GameObject.Find("Bomb").GetComponent<SpawnBomb>().time = Time.time;
				anim.SetBool ("Boom", true);
				GameObject.Find ("Bomb").transform.position = GameObject.Find ("Bomb(Clone)").transform.position;
				if(Physics2D.CircleCast (GameObject.Find ("Bomb(Clone)").transform.position, 0.595f, Vector2.down, 0.595f, 1 << LayerMask.NameToLayer ("LeftPlayer"))){
					GameObject.Find ("Bomb").GetComponent<SpawnBomb>().left_bombed = true;
				}
				if(Physics2D.CircleCast (GameObject.Find ("Bomb(Clone)").transform.position, 0.595f, Vector2.down, 0.595f, 1 << LayerMask.NameToLayer ("RightPlayer"))){
					GameObject.Find ("Bomb").GetComponent<SpawnBomb>().right_bombed = true;
				}
				GameObject.Find ("Bomb").GetComponent<SpawnBomb>().spawn = false;
				GameObject.Find ("Bomb(Clone)").GetComponent<Rigidbody2D>().isKinematic = true;
				Destroy(GameObject.Find ("Bomb(Clone)"));
				GameObject.Find ("Ball").GetComponent<Ball> ().Nbomb -=1;
			}
		}
		if (GameObject.Find ("Bomb").GetComponent<SpawnBomb> ().left_bombed && GameObject.Find ("Bomb").GetComponent<SpawnBomb> ().right_bombed &&!restart) {
			restart = true;
			time_restart = Time.time;
		}
		if (restart)
		if (Time.time - time_restart > 5)
			//Application.LoadLevel (Application.loadedLevel);
			SceneManager.LoadScene (1, LoadSceneMode.Single);
	}
}
