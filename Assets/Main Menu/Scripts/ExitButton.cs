using UnityEngine;
using System.Collections;

public class ExitButton : MonoBehaviour {
	private Animator anim;
	void Start(){
		anim = GetComponent<Animator> ();
	}
	void OnMouseOver()
	{
		if(!GameObject.Find("Play").GetComponent<PlayButton>().move&&!GameObject.Find("BackArrow").GetComponent<BackArrow>().move)
			anim.SetBool ("Mouse", true);
	}
	void OnMouseExit()
	{
		anim.SetBool ("Mouse", false);
	}
	void OnMouseDown() 
	{
		if (!GameObject.Find ("Play").GetComponent<PlayButton> ().move && !GameObject.Find ("BackArrow").GetComponent<BackArrow> ().move&&!GameObject.Find ("SettingsButton").GetComponent<SettingsButton> ().active&&!GameObject.Find ("Help").GetComponent<HelpButton> ().active) {
			GetComponent<AudioSource> ().Play ();
			Application.Quit ();
		}
	}
}
