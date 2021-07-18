using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class SettingsButton : MonoBehaviour {
	public bool active,XSound;
	public GameObject window;
	private Animator anim;
	void Start(){
		anim = GetComponent<Animator> ();
	}
	void OnMouseOver()
	{
		if (!GameObject.Find ("Help").GetComponent<HelpButton> ().active)
			anim.SetBool ("Mouse", true);
	}
	void OnMouseExit()
	{
		anim.SetBool ("Mouse", false);
	}
	void OnMouseDown() 
	{
		if (!active&&!GameObject.Find("Start").GetComponent<StartButton>().load&&!GameObject.Find("Help").GetComponent<HelpButton>().active) {
			GetComponent<AudioSource> ().Play ();
			window.SetActive (true);
			this.GetComponent<SpriteRenderer> ().enabled = false;
			active = true;
		}
	}
	void Update(){
		if (XSound) {
			transform.GetChild (0).GetComponent<AudioSource> ().Play ();
			XSound = false;
		}
	}
}