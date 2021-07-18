using UnityEngine;
using System.Collections;

public class GOOOOAL : MonoBehaviour {
	public Transform CheckGoalUp, CheckGoalDown;
	public bool goal,l,r;
	public Vector3 b,n,p;
	public float left,right;

	void Start () {
		goal=false;
		b.x = 0.8f;
		b.y = 1.3f;
		b.z = 1f;
		n.x = 0.8f;
		n.y = 1f;
		n.z = 1f;
	}
	

	void Update () {
		if (!GameObject.Find ("Score").GetComponent<Score> ().win) 
			goal = Physics2D.Linecast (CheckGoalUp.position, CheckGoalDown.position, 1 << LayerMask.NameToLayer ("GoalMark"));
		if (GameObject.Find ("Ball").GetComponent<Ball> ().left_goal) {
			p.x = -14.92f;
			p.y = -5.2f;
			p.z = -4f;
			left = GameObject.Find ("Ball").GetComponent<Ball> ().time_big_goal;
			GameObject.Find ("LeftGoalGate").transform.position = p;
			GameObject.Find ("LeftGoalGate").transform.localScale = b;
			GameObject.Find ("Ball").GetComponent<Ball> ().left_goal = false;
			l = true;
		}
		if (l) {		
			if (Time.time - left > 10) {
				p.x = -14.92f;
				p.y = -5.8f;
				p.z = -4f;
				GameObject.Find ("LeftGoalGate").transform.position = p;
				GameObject.Find ("LeftGoalGate").transform.localScale = n;
				l = false;
			}
		}
			if (GameObject.Find ("Ball").GetComponent<Ball> ().right_goal) {
			p.x = 16.78f;
			p.y = -5.2f;
			p.z = -4f;
			right = GameObject.Find ("Ball").GetComponent<Ball> ().time_big_goal;
			GameObject.Find ("RightGoalGate").transform.position = p;
			GameObject.Find ("RightGoalGate").transform.localScale = b;
			GameObject.Find ("Ball").GetComponent<Ball> ().right_goal = false;
			r= true;
		}
		if (r) {		
			if (Time.time - right > 10) {
				p.x = 16.78f;
				p.y = -5.8f;
				p.z = -4f;
				GameObject.Find ("RightGoalGate").transform.position = p;
				GameObject.Find ("RightGoalGate").transform.localScale = n;
				r = false;
			}
		}
	}
}
