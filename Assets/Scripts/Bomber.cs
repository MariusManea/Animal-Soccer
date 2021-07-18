using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
public class Bomber : MonoBehaviour {

	public GameObject ball,bomb;
	public bool spawn,left_bombed, right_bombed,restart;
	public Vector3 pos;
	public float time_restart;

	void Start () {
		ball = GameObject.Find ("Ball");
		pos.y = 11f;
		pos.z = -3.5f;
	}
	

	void Update () {
		if (ball.GetComponent<Ball> ().Nbomb > 0 && !spawn) {
			bomb = GameObject.Instantiate (Resources.Load ("Bomb")) as GameObject;
			spawn = true;
			pos.x = Random.Range (-9.5f, 10f);
			bomb.transform.position = pos;
		}
		if (left_bombed && right_bombed && !restart) {
			restart = true;
			time_restart = Time.time;
		}
		if (restart&&!GameObject.Find("Score").GetComponent<Score>().goal) {
			if (Time.time - time_restart > 5)
				//Application.LoadLevel (Application.loadedLevel);
				SceneManager.LoadScene(1,LoadSceneMode.Single);
		}
	}
}
