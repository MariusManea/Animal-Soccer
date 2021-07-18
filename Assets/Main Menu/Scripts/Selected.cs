using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Selected : MonoBehaviour {
	
	public int Left_Animal, Right_Animal,Mode,BackGround,Obstacle,backGround,mute;
	public bool powerups,sem;
	public float time,initial_time,SVolume,MVolume;
	public static Selected Instance;
	public Sprite[] BG, Ground, Table, Obstacles;
	public KeyCode[] Keys;
	void Start () {
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
	void Awake(){
		Application.targetFrameRate = 60;
	}
	void Update (){
		if (/*Application.loadedLevel == 0*/SceneManager.GetActiveScene().buildIndex == 0) {
			time = initial_time;
			Left_Animal = GameObject.Find ("Left_Arrow_Button").GetComponent<Left_Left_Arrow_Button> ().animal;
			Right_Animal = GameObject.Find ("Right_Arrow_Button").GetComponent<Right_Left_Arrow_Button> ().animal;
			Mode = GameObject.Find ("Mods_Arrow_Button").GetComponent<Left_Mods_Arrow_Button>().mode;
			sem = false;
		}
		if (SceneManager.GetActiveScene ().buildIndex == 1) {
			if (BackGround == 8) {
				if (!sem) {
					sem = true;
					backGround = Random.Range (0, 7);
				}
			}
			else
				backGround = BackGround;
			GameObject.Find ("Background").GetComponent<SpriteRenderer> ().sprite = BG [backGround];
			GameObject.Find ("Ground").GetComponent<SpriteRenderer> ().sprite = Ground [backGround];
			GameObject.Find ("LeftScoreTable").GetComponent<SpriteRenderer> ().sprite = Table [backGround];
			GameObject.Find ("RightScoreTable").GetComponent<SpriteRenderer> ().sprite = Table [backGround];
			if (Obstacle>0&&!GameObject.Find ("Obstacles").GetComponent<PolygonCollider2D>()) {
				GameObject.Find ("Obstacles").GetComponent<SpriteRenderer> ().sprite = Obstacles [Obstacle];
				GameObject.Find ("Obstacles").AddComponent<PolygonCollider2D> ();
			}

		}
		if (SceneManager.GetActiveScene ().buildIndex == 1 && Mode == 1)
		if (!GameObject.Find ("Score").GetComponent<Score> ().goal)
			time -= Time.deltaTime;
	}
}
