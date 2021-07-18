 using UnityEngine;
 using System.Collections;
 using UnityEngine.UI;
 
 public class Timer : MonoBehaviour {
    public Text timerLabel;
	public int minutes, seconds;
    public float time;

	void Awake(){
		minutes = Mathf.FloorToInt (time) / 60; 
		seconds = Mathf.FloorToInt (time) % 60;
	}

    void Update() {
		if (time > 1&&!GameObject.Find("Score").GetComponent<Score>().goal) {
			time -= Time.deltaTime;
			if (seconds <= 11 && time <= 11) {
				timerLabel.color = Color.red;
				if (Mathf.FloorToInt (time) % 60 != seconds)
					GetComponent<AudioSource> ().Play ();
			}
			minutes = Mathf.FloorToInt (time) / 60; 
			seconds = Mathf.FloorToInt (time) % 60;
			timerLabel.text = string.Format ("{0:00}:{1:00}", minutes, seconds);
		}
	}
}