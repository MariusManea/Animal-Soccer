using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour {

	public bool left,right;
	public bool bouncy,dead,grow,shrink,big,small,big_goal,rBig_goal,freeze,rFreeze,speedUp,slow,bomb,broke,rBroke,wall,rWall,cannon;
	public float time_time,time_bouncy, time_dead,time_grow, time_shrink,time_big,time_small,time_big_goal,time_freeze,time_SpeedUp,time_slow,time_broke,time_wall,time_cannon;
	public bool left_grow, right_grow, left_shrink, right_shrink, left_goal, right_goal,left_freeze,right_freeze,left_SpeedUp,right_SpeedUp,left_slow,right_slow,left_broke,right_broke,left_wall,right_wall;
	public Vector3 b,n,s,C,Null;
	public float radius;
	public int Nbomb = 0;
	private Animator anim, anim_writing;
	public GameObject hitEffect;
	public ParticleSystem.ShapeModule shape;
	public ParticleSystem system;
	void Start () { 
		anim = GetComponent<Animator> ();
		anim_writing = GameObject.Find ("Writing").GetComponent<Animator> ();
		b.x = 0.35f;
		b.y = 0.35f;
		b.z = 1f;
		n.x = 0.25f;
		n.y = 0.25f;
		n.z = 1f;
		s.x = 0.15f;
		s.y = 0.15f;
		s.z = 1f;
		C.z = 0f;
		C.x = 0.85f;
		C.y = 12.25f;
		radius = 0.555f;
		GetComponent<Rigidbody2D> ().AddForce (Vector2.up * 100f );
		GameObject.Find("Bouncy").GetComponent<CircleCollider2D> ().enabled = false;
		GameObject.Find("Dead").GetComponent<CircleCollider2D> ().enabled = false;
	}
	void Awake()
	{
		if (GameObject.Find ("Score").GetComponent<Score> ().left_advantage) {
			GameObject.Find ("Ball").GetComponent<Rigidbody2D> ().AddForce (Vector2.left * 370f);
			left = true;
			right = false;
		} 
		if (GameObject.Find ("Score").GetComponent<Score> ().right_advantage) {
			GameObject.Find ("Ball").GetComponent<Rigidbody2D> ().AddForce (Vector2.right * 370f);
			left = false;
			right = true;
		}
	}
	void Update () {
		//PowerUps
		//Bouncy_Ball
		if(bouncy){
			anim.SetBool ("Bouncy", true);
			anim.SetBool ("Dead", false);
			GameObject.Find("Bouncy").GetComponent<CircleCollider2D> ().enabled = true;
			GameObject.Find("Dead").GetComponent<CircleCollider2D> ().enabled = false;
			GameObject.Find("Normal").GetComponent<CircleCollider2D> ().enabled = false;
			if(Time.time - time_bouncy > 10) {
				anim.SetBool ("Bouncy", false);
				GameObject.Find("Bouncy").GetComponent<CircleCollider2D> ().enabled = false;
				GameObject.Find("Dead").GetComponent<CircleCollider2D> ().enabled = false;
				GameObject.Find("Normal").GetComponent<CircleCollider2D> ().enabled = true;
				bouncy = false;
			}
		}
		//Dead_Ball
		if(dead){
			anim.SetBool ("Dead", true);
			anim.SetBool ("Bouncy", false);
			GameObject.Find("Dead").GetComponent<CircleCollider2D> ().enabled = true;
			GameObject.Find("Bouncy").GetComponent<CircleCollider2D> ().enabled = false;
			GameObject.Find("Normal").GetComponent<CircleCollider2D> ().enabled = false;
			if(Time.time - time_dead > 10) {
				anim.SetBool ("Dead", false);
				GameObject.Find("Dead").GetComponent<CircleCollider2D> ().enabled = false;
				GameObject.Find("Bouncy").GetComponent<CircleCollider2D> ().enabled = false;
				GameObject.Find("Normal").GetComponent<CircleCollider2D> ().enabled = true;
				dead = false;
			}
		}
		//Grow
		if (grow) {
			if(left == true){
				left_grow = true;
				GameObject.Find ("LeftGrowthAnim").GetComponent<Animator>().SetTrigger("Grow");
				left_shrink = false;
				grow = false;
				GameObject.Find ("LEFT").GetComponent<LeftPlayerMovement> ().time_grow = time_grow;
				}
			if(right == true){
				right_grow = true;
				GameObject.Find ("RightGrowthAnim").GetComponent<Animator>().SetTrigger("Grow");
				right_shrink = false;
				grow = false;
				GameObject.Find ("RIGHT").GetComponent<RightPlayerMovement> ().time_grow = time_grow;
				}

			}
		//Shrink
		if (shrink) {
			if(left == true){
				left_shrink = true;
				GameObject.Find ("LeftGrowthAnim").GetComponent<Animator>().SetTrigger("Shrink");
				left_grow = false;
				shrink = false;
				GameObject.Find ("LEFT").GetComponent<LeftPlayerMovement> ().time_shrink = time_shrink;
			}
			if(right == true){
				right_shrink = true;
				GameObject.Find ("RightGrowthAnim").GetComponent<Animator>().SetTrigger("Shrink");
				right_grow = false;
				shrink = false;
				GameObject.Find ("RIGHT").GetComponent<RightPlayerMovement> ().time_shrink = time_shrink;
			}
			
		}
		//Big_Ball
		if (big) {
			radius = 0.777f;
			this.transform.localScale = b;
			if(Time.time - time_big > 10){
				big = false;
				radius = 0.555f;
				this.transform.localScale = n;
			}
		}
		//Small_Ball
		if (small) {
			radius = 0.4f;
			this.transform.localScale = s;
			if(Time.time - time_small > 10){
				small = false;
				radius = 0.555f;
				this.transform.localScale = n;
			}
		}
		//Big_Goal
		if (big_goal) {
			if(left){
				right_goal = true ;
				big_goal = false;
			}
			if(right){
				left_goal = true;
				big_goal = false;
			}
		}
		//Enemy_Big_Goal
		if (rBig_goal) {
			if(left){
				left_goal = true ;
				rBig_goal = false;
			}
			if(right){
				right_goal = true;
				rBig_goal = false;
			}
		}
		//Enemy_Freeze
		if (freeze) {
			if(left){
				right_freeze = true ;
				GameObject.Find ("RIGHT").GetComponent<RightPlayerMovement> ().time_freeze = time_freeze;
				freeze = false;
			}
			if(right){
				left_freeze = true;
				GameObject.Find ("LEFT").GetComponent<LeftPlayerMovement> ().time_freeze = time_freeze;
				freeze = false;
			}
		}
		//Self_Freeze
		if (rFreeze) {
			if(left){
				left_freeze = true ;
				GameObject.Find ("LEFT").GetComponent<LeftPlayerMovement> ().time_freeze = time_freeze;
				rFreeze = false;
			}
			if(right){
				right_freeze = true;
				GameObject.Find ("RIGHT").GetComponent<RightPlayerMovement> ().time_freeze = time_freeze;
				rFreeze = false;
			}
		}
		//SpeedUp
		if (speedUp) {
			if(left){
				left_SpeedUp = true ;
				GameObject.Find ("LeftSpeedAnim").GetComponent<Animator>().SetTrigger("Speed");
				GameObject.Find ("LEFT").GetComponent<LeftPlayerMovement> ().time_SpeedUp = time_SpeedUp;
				speedUp = false;
				left_slow = false;
			}
			if(right){
				right_SpeedUp = true;
				GameObject.Find ("RightSpeedAnim").GetComponent<Animator>().SetTrigger("Speed");
				GameObject.Find ("RIGHT").GetComponent<RightPlayerMovement> ().time_SpeedUp = time_SpeedUp;
				speedUp = false;
				right_slow = false;
			}
		}
		//Slow
		if (slow) {
			if(left){
				slow = false;
				GameObject.Find ("LeftSpeedAnim").GetComponent<Animator>().SetTrigger("Slow");
				GameObject.Find ("LEFT").GetComponent<LeftPlayerMovement> ().time_slow = time_slow;
				left_slow = true ;
				left_SpeedUp = false;
			}
			if(right){
				slow = false;
				GameObject.Find ("RightSpeedAnim").GetComponent<Animator>().SetTrigger("Slow");
				GameObject.Find ("RIGHT").GetComponent<RightPlayerMovement> ().time_slow = time_slow;
				right_slow = true;
				right_SpeedUp = false;
			}
		}
		//Bombs
		if (GameObject.Find ("Bombs")) {
			if (GameObject.Find ("Bombs").GetComponent<Bomb> ().triggered)
				bomb = true;
		}
		if (bomb) {
			Nbomb += 5;
			bomb = false;
		}
		//EnemyHandBreak
		if (broke) {
			if(left){
				broke = false;
				right_broke = true ;
				GameObject.Find ("RIGHT").GetComponent<RightPlayerMovement> ().time_broke = time_broke;
			}
			if(right){
				broke = false;
				left_broke = true;
				GameObject.Find ("LEFT").GetComponent<LeftPlayerMovement> ().time_broke = time_broke;
			}
		}
		//HandBreak
		if (rBroke) {
			if(left){
				rBroke = false;
				left_broke = true ;
				GameObject.Find ("LEFT").GetComponent<LeftPlayerMovement> ().time_broke = time_broke;
			}
			if(right){
				rBroke = false;
				right_broke = true;
				GameObject.Find ("RIGHT").GetComponent<RightPlayerMovement> ().time_broke = time_broke;
			}
		}
		//Ally_Wall
		if (wall) {
			if(left){
				wall = false;
				left_wall = true;
				GameObject.Find ("Left_Brick_Wall").GetComponent<Left_Wall> ().time = time_wall;
			}
			if(right){
				wall = false;
				right_wall = true;
				GameObject.Find ("Right_Brick_Wall").GetComponent<Right_Wall> ().time = time_wall;
			}
		}
		//Enemy_Wall
		if (rWall) {
			if(left){
				rWall = false;
				right_wall = true;
				GameObject.Find ("Right_Brick_Wall").GetComponent<Right_Wall> ().time = time_wall;
			}
			if(right){
				rWall = false;
				left_wall = true;
				GameObject.Find ("Left_Brick_Wall").GetComponent<Left_Wall> ().time = time_wall;
			}
		}
		//Cannon
		if (cannon) {
			GameObject.Find ("Cannon").GetComponent<SuperCannon> ().time = time_cannon;
			GameObject.Find ("Cannon").GetComponent<SuperCannon> ().cannon = true;
			GameObject.Find ("Cannon").GetComponent<SuperCannon> ().choose = false;
			GameObject.Find ("SmashSound").GetComponent<CircleCollider2D> ().enabled = false;
			GameObject.Find("Ball").GetComponent<Rigidbody2D>().velocity = Null;
			GameObject.Find ("Cannon").GetComponent<SpriteRenderer> ().enabled = true;
			GameObject.Find ("LeftWall").GetComponent<BoxCollider2D> ().enabled = true;
			GameObject.Find ("RightWall").GetComponent<BoxCollider2D> ().enabled = true;
			GameObject.Find ("XLeftWall").GetComponent<BoxCollider2D> ().enabled = true;
			GameObject.Find ("XRightWall").GetComponent<BoxCollider2D> ().enabled = true;
			GameObject.Find ("Platform").GetComponent<BoxCollider2D> ().enabled = true;
			GameObject.Find ("CannonEnd").GetComponent<BoxCollider2D> ().enabled = true;
			GameObject.Find ("Stand").GetComponent<SpriteRenderer> ().enabled = true;
			GameObject.Find ("Stand").GetComponent<BoxCollider2D> ().enabled = true;
			cannon = false;
		}
		if (Time.time - time_time > 1 && !GameObject.Find ("Score").GetComponent<Score>().goal && !GameObject.Find ("Score").GetComponent<Score>().win)
			anim_writing.SetInteger ("Writing", 0);
		//LastTouch ();
	}

	/*void LastTouch(){
		if (Physics2D.CircleCast (this.transform.position, radius, Vector2.down, radius, 1 << LayerMask.NameToLayer ("LeftPlayer"))) {
			left = true;
			right = false;
		}
		if (Physics2D.CircleCast (this.transform.position, radius, Vector2.down, radius, 1 << LayerMask.NameToLayer ("RightPlayer"))) {
			left = false;
			right = true;
		}
		if (Physics2D.CircleCast (this.transform.position, radius, Vector2.up, radius, 1 << LayerMask.NameToLayer ("LeftPlayer"))) {
			left = true;
			right = false;
		}
		if (Physics2D.CircleCast (this.transform.position, radius, Vector2.up, radius, 1 << LayerMask.NameToLayer ("RightPlayer"))) {
			left = false;
			right = true;
		}
		if (Physics2D.CircleCast (this.transform.position, radius, Vector2.left, radius, 1 << LayerMask.NameToLayer ("LeftPlayer"))) {
			left = true;
			right = false;
		}
		if (Physics2D.CircleCast (this.transform.position, radius, Vector2.left, radius, 1 << LayerMask.NameToLayer ("RightPlayer"))) {
			left = false;
			right = true;
		}
		if (Physics2D.CircleCast (this.transform.position, radius, Vector2.right, radius, 1 << LayerMask.NameToLayer ("LeftPlayer"))) {
			left = true;
			right = false;
		}
		if (Physics2D.CircleCast (this.transform.position, radius, Vector2.right, radius, 1 << LayerMask.NameToLayer ("RightPlayer"))) {
			left = false;
			right = true;
		}
	}*/

	/*void OnTriggerStay2D(Collider2D other)
	{
		if (other.name == "LEFT") {
			left = true;
			right = false;
		}
		if (other.name == "RIGHT") {
			left = false;
			right = true;
		}
	}*/

	void OnCollisionEnter2D(Collision2D other){
		if (other.relativeVelocity.magnitude > 7f&&other.gameObject.layer != 12) {
			hitEffect = Instantiate (GameObject.Find ("HitEffect"), new Vector3 (this.transform.position.x, this.transform.position.y, -20f), this.transform.rotation);
			system = hitEffect.GetComponent<ParticleSystem> ();
			shape = system.shape;
			shape.radius = radius;
			hitEffect.GetComponent<ParticleSystem> ().Play ();
			Destroy (hitEffect, 1f);
			GameObject.Find ("SmashSound").GetComponent<CollisionSound> ().sources [GameObject.Find ("SmashSound").GetComponent<CollisionSound> ().state].Play ();
		}
	}
}
