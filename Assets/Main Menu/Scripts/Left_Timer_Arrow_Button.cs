using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Left_Timer_Arrow_Button : MonoBehaviour {

	public GameObject master;
	private Animator anim1;
	void Start(){
		anim1 = GetComponent<Animator> ();
		master = GameObject.Find ("Selected");
	}
	void OnMouseDown() 
	{ 
		if (master.GetComponent<Selected>().initial_time>60f) {
			GetComponent<AudioSource> ().Play ();
			master.GetComponent<Selected> ().initial_time -= 60f;
			}
	}
	void Update()
	{
		if (master.GetComponent<Selected> ().initial_time == 60f)
			anim1.SetBool ("Blocked", true);
		else
			anim1.SetBool ("Blocked", false);
		return;
	}
}
