using UnityEngine;
using System.Collections;

public class SwitchButton : MonoBehaviour {
	private Animator anim;
	public GameObject toActivate, toDeactivate;
	void Start(){
		anim=GetComponent<Animator> ();
	}
	void OnMouseOver()
	{
		anim.SetBool ("Mouse", true);
	}
	void OnMouseExit()
	{
		anim.SetBool ("Mouse", false);
	}
	void OnMouseDown() 
	{
		toDeactivate.SetActive (false);
		toActivate.SetActive (true);
		toActivate.transform.GetChild (0).GetComponent<AudioSource> ().Play ();
	}
		
}
