using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Score : MonoBehaviour 
{
	public static Score Instance;
	private Animator anim1,anim2,anim3,anim4,anim_writing;//anim_timer1,anim_timer2;
	public float time_goal,time,timeT;
	public int animal_left, animal_right, remaining_time,a,b;
	public bool left_advantage ,right_advantage ,goal,win=false,started,whistle;
	public GameObject left,right,timer;
	public Selected master;
	void Awake ()   
	{ 
		master = GameObject.Find ("Selected").GetComponent<Selected> ();
		animal_left = GameObject.Find ("Selected").GetComponent<Selected> ().Left_Animal;
		animal_right = GameObject.Find ("Selected").GetComponent<Selected> ().Right_Animal;
		anim_writing = GameObject.Find ("Writing").GetComponent<Animator> ();
		anim1 = GameObject.Find ("Left_Left_Cypher").GetComponent <Animator> ();
		anim2 = GameObject.Find ("Left_Right_Cypher").GetComponent <Animator> ();
		anim3 = GameObject.Find ("Right_Left_Cypher").GetComponent <Animator> ();
		anim4 = GameObject.Find ("Right_Right_Cypher").GetComponent <Animator> ();
		//anim_timer1 = GameObject.Find ("LeftTimer").GetComponent <Animator> ();
		//anim_timer2 = GameObject.Find ("RightTimer").GetComponent <Animator> ();
		timer = GameObject.Find ("Timer");
		if (GameObject.Find("Selected").GetComponent<Selected>().Mode == 1) timer.GetComponent<Timer>().time = GameObject.Find("Selected").GetComponent<Selected>().time;
		if (Instance == null)
		{
			DontDestroyOnLoad(gameObject);
			Instance = this;
		}
		else if (Instance != this)
		{
			Destroy (gameObject);
		}
		switch (animal_left) {
		case 1:
			{
				left = GameObject.Instantiate (Resources.Load ("Left_Fox")) as GameObject;
				break;
			}
		case 2:
			{
				left = GameObject.Instantiate (Resources.Load ("Left_Stag")) as GameObject;
				break;
			}
		case 3:
			{
				left = GameObject.Instantiate (Resources.Load ("Left_Bear")) as GameObject;
				break;
			}
		case 4:
			{
				left = GameObject.Instantiate (Resources.Load ("Left_Ram")) as GameObject;
				break;
			}
		case 5:
			{
				left = GameObject.Instantiate (Resources.Load ("Left_Lion")) as GameObject;
				break;
			}
		case 6:
			{
				left = GameObject.Instantiate (Resources.Load ("Left_Kangaroo")) as GameObject;
				break;
			}
		case 7:
			{
				left = GameObject.Instantiate (Resources.Load ("Left_Monkey")) as GameObject;
				break;
			}
		case 8:
			{
				left = GameObject.Instantiate (Resources.Load ("Left_Boar")) as GameObject;
				break;
			}
		case 9:
			{
				left = GameObject.Instantiate (Resources.Load ("Left_Bull")) as GameObject;
				break;
			}
		case 10:
			{
				left = GameObject.Instantiate (Resources.Load ("Left_Beaver")) as GameObject;
				break;
			}
		case 11:
			{
				left = GameObject.Instantiate (Resources.Load ("Left_Zebra")) as GameObject;
				break;
			}
		case 12:
			{
				left = GameObject.Instantiate (Resources.Load ("Left_Wolf")) as GameObject;
				break;
			}
		case 13:
			{
				left = GameObject.Instantiate (Resources.Load ("Left_Tiger")) as GameObject;
				break;
			}
		case 14:
			{
				left = GameObject.Instantiate (Resources.Load ("Left_Crocodile")) as GameObject;
				break;
			}
		case 15:
			{
				left = GameObject.Instantiate (Resources.Load ("Left_Penguin")) as GameObject;
				break;
			}
		default:
			{
				break;
			}
		}

		switch (animal_right) {
		case 1:
			{
				right = GameObject.Instantiate (Resources.Load ("Right_Fox")) as GameObject;
				break;
			}
		case 2:
			{
				right = GameObject.Instantiate (Resources.Load ("Right_Stag")) as GameObject;
				break;
			}
		case 3:
			{
				right = GameObject.Instantiate (Resources.Load ("Right_Bear")) as GameObject;
				break;
			}
		case 4:
			{
				right = GameObject.Instantiate (Resources.Load ("Right_Ram")) as GameObject;
				break;
			}
		case 5:
			{
				right = GameObject.Instantiate (Resources.Load ("Right_Lion")) as GameObject;
				break;
			}
		case 6:
			{
				right = GameObject.Instantiate (Resources.Load ("Right_Kangaroo")) as GameObject;
				break;
			}
		case 7:
			{
				right = GameObject.Instantiate (Resources.Load ("Right_Monkey")) as GameObject;
				break;
			}
		case 8:
			{
				right = GameObject.Instantiate (Resources.Load ("Right_Boar")) as GameObject;
				break;
			}
		case 9:
			{
				right = GameObject.Instantiate (Resources.Load ("Right_Bull")) as GameObject;
				break;
			}
		case 10:
			{
				right = GameObject.Instantiate (Resources.Load ("Right_Beaver")) as GameObject;
				break;
			}
		case 11:
			{
				right = GameObject.Instantiate (Resources.Load ("Right_Zebra")) as GameObject;
				break;
			}
		case 12:
			{
				right = GameObject.Instantiate (Resources.Load ("Right_Wolf")) as GameObject;
				break;
			}
		case 13:
			{
				right = GameObject.Instantiate (Resources.Load ("Right_Tiger")) as GameObject;
				break;
			}
		case 14:
			{
				right = GameObject.Instantiate (Resources.Load ("Right_Crocodile")) as GameObject;
				break;
			}
		case 15:
			{
				right = GameObject.Instantiate (Resources.Load ("Right_Penguin")) as GameObject;
				break;
			}
		default:
			{
				break;
			}
		}
		left.name = "LEFT";
		right.name = "RIGHT";
	}
	public int left_score , right_score;
	GameObject left_goalgate , right_goalgate;

	void Start () { 
		Application.targetFrameRate = 60;
		//anim_timer1.SetBool("Timed", false);
		//anim_timer2.SetBool("Timed", false);
		GameObject.Find ("Mute").GetComponent<Mute_Control> ().Start ();
		if (Instance == null)
		{
			DontDestroyOnLoad(gameObject);
			Instance = this;
		}
		else if (Instance != this)
		{
			Destroy (gameObject);
		}

	}

	void Update () { 
		timer = GameObject.Find ("Timer");
		if (/*Application.loadedLevel == 0*/SceneManager.GetActiveScene ().buildIndex == 0) {
			GameObject.DestroyImmediate (this.gameObject);
			time = Time.time;
		} else {
			anim_writing = GameObject.Find ("Writing").GetComponent<Animator> ();
			left_goalgate = GameObject.Find ("LeftGoalGate");
			right_goalgate = GameObject.Find ("RightGoalGate");
			if (win)right_goalgate.GetComponent<AudioSource> ().mute = true;
			if (right_goalgate.GetComponent<GOOOOAL> ().goal && !goal) {
				if(!win)right_goalgate.GetComponent<AudioSource> ().Play ();
				GameObject.Find ("LeftArm").GetComponent<AudioSource> ().Play ();
				left_score += 1;
				left_advantage = true; 
				right_advantage = false;
				anim1.SetInteger ("Cypher", left_score % 100 / 10);
				anim2.SetInteger ("Cypher", left_score % 10);
				anim_writing.SetInteger ("Writing", 6);
				goal = true;
				time_goal = Time.time;
			}
			if (win)left_goalgate.GetComponent<AudioSource> ().mute = true;
			if (left_goalgate.GetComponent<GOOOOAL> ().goal && !goal) {
				if(!win)left_goalgate.GetComponent<AudioSource> ().Play ();
				GameObject.Find ("RightArm").GetComponent<AudioSource> ().Play ();
				right_score += 1;
				left_advantage = false;
				right_advantage = true;
				anim3.SetInteger ("Cypher", right_score % 100 / 10);
				anim4.SetInteger ("Cypher", right_score % 10);
				anim_writing.SetInteger ("Writing", 6);
				goal = true;
				time_goal = Time.time;
			}
			if (goal)
			if (Time.time - time_goal > 2 && !win) {
				goal = false;
				time = timer.GetComponent<Timer> ().time;
				//Application.LoadLevel (Application.loadedLevel);
				SceneManager.LoadScene (1, LoadSceneMode.Single);
			}
			if (Input.GetKeyDown (master.Keys[8])) { 
				GameObject.Find ("AreYouSure").GetComponent<Pause_Control> ().emit = true;
				GameObject.Find ("AreYouSure").GetComponent<SpriteRenderer> ().enabled = !GameObject.Find ("AreYouSure").GetComponent<SpriteRenderer> ().enabled;
				GameObject.Find ("Yes").GetComponent<SpriteRenderer> ().enabled = !GameObject.Find ("Yes").GetComponent<SpriteRenderer> ().enabled;
				GameObject.Find ("No").GetComponent<SpriteRenderer> ().enabled = !GameObject.Find ("No").GetComponent<SpriteRenderer> ().enabled;
				GameObject.Find ("Yes").GetComponent<BoxCollider2D> ().enabled = !GameObject.Find ("Yes").GetComponent<BoxCollider2D> ().enabled;
				GameObject.Find ("No").GetComponent<BoxCollider2D> ().enabled = !GameObject.Find ("No").GetComponent<BoxCollider2D> ().enabled;
				Time.timeScale = 1 - Time.timeScale;
			}

			if (/*Application.loadedLevel == 1*/SceneManager.GetActiveScene ().buildIndex == 1) {
				if (GameObject.Find ("Selected").GetComponent<Selected> ().Mode == 1) {
					//anim_timer1.SetBool("Timed", true);
					//anim_timer2.SetBool("Timed", true);
					if (!started) {
						time = Time.time;
						started = true;
					}
					if (timer.GetComponent<Timer> ().time <= 1f) {
						if (left_score > right_score && !win) {
							timeT = Time.time;
							win = true;
							whistle = true;
							anim_writing.SetInteger ("Writing", 7);
						}
						if (left_score < right_score && !win) {
							timeT = Time.time;
							win = true;
							whistle = true;
							anim_writing.SetInteger ("Writing", 8);
						}
						if (left_score == right_score && !win) {
							timeT = Time.time;
							win = true;
							whistle = true;
							anim_writing.SetInteger ("Writing", 9);
						}
						if (whistle) {
							GameObject.Find("Ball").GetComponent<AudioSource> ().Play ();
							whistle = false;
						}
						if (win) {
							if (Time.time - timeT > 2) {
								win = false; 
								//Application.LoadLevel(Application.loadedLevel - 1);
								SceneManager.LoadScene (0, LoadSceneMode.Single);
							}
						}
					}
					//TimerAlpha
					/*remaining_time = 60 - Mathf.RoundToInt(Time.time) + Mathf.RoundToInt(time);  
				a=remaining_time/10;
				b=remaining_time%10;
				anim_timer1.SetInteger("Cypher" , a);
				anim_timer2.SetInteger("Cypher" , b);*/
				}
				if (GameObject.Find ("Selected").GetComponent<Selected> ().Mode == 2) {
					if (left_score == 10 && right_score != 10 && !win) {
						time = Time.time;
						win = true;
						whistle = true;
						anim_writing.SetInteger ("Writing", 7);
					}
					if (left_score != 10 && right_score == 10 && !win) { 
						time = Time.time;
						win = true;
						whistle = true;
						anim_writing.SetInteger ("Writing", 8);
					}
					if (whistle) {
						GameObject.Find("Ball").GetComponent<AudioSource> ().Play ();
						whistle = false;
					}
					if (win) {
						if (Time.time - time > 2) {
							win = false; 
							//Application.LoadLevel(Application.loadedLevel - 1);
							SceneManager.LoadScene (0, LoadSceneMode.Single);
						}
					}
				}
				if (GameObject.Find ("Selected").GetComponent<Selected> ().Mode == 3) {
					if (left_score == 20 && right_score != 20 && !win) {
						time = Time.time;
						win = true;
						whistle = true;
						anim_writing.SetInteger ("Writing", 7);
					}
					if (left_score != 20 && right_score == 20 && !win) { 
						time = Time.time;
						win = true;
						whistle = true;
						anim_writing.SetInteger ("Writing", 8);
					}
					if (whistle) {
						GameObject.Find("Ball").GetComponent<AudioSource> ().Play ();
						whistle = false;
					}
					if (win) {
						if (Time.time - time > 2) {
							win = false; 
							//Application.LoadLevel(Application.loadedLevel - 1);
							SceneManager.LoadScene (0, LoadSceneMode.Single);
						}
					}
				}
			}
		}
	}
	void OnApplicationPause(bool Paused)
	{
		if (Paused) {
			GameObject.Find ("AreYouSure").GetComponent<Pause_Control> ().emit = Paused;
			GameObject.Find ("AreYouSure").GetComponent<SpriteRenderer> ().enabled = true;
			GameObject.Find ("Yes").GetComponent<SpriteRenderer> ().enabled = true;
			GameObject.Find ("No").GetComponent<SpriteRenderer> ().enabled = true;
			GameObject.Find ("Yes").GetComponent<BoxCollider2D> ().enabled = true;
			GameObject.Find ("No").GetComponent<BoxCollider2D> ().enabled = true;
			Time.timeScale = 0;
		}
	}
}
