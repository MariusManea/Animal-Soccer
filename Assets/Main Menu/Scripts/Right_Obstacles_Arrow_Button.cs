using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Right_Obstacles_Arrow_Button : MonoBehaviour {

	public GameObject master;
	private Animator anim1;
	void Start(){
		anim1 = GetComponent<Animator> ();
		master = GameObject.Find ("Selected");
	}
	void OnMouseDown() 
	{ 
		if (master.GetComponent<Selected>().Obstacle<10) {
			GetComponent<AudioSource> ().Play ();
			master.GetComponent<Selected> ().Obstacle ++;
		}
	}
	void Update()
	{
		if (master.GetComponent<Selected> ().Obstacle == 10)
			anim1.SetBool ("Blocked", true);
		else
			anim1.SetBool ("Blocked", false);
		return;
	}
}
