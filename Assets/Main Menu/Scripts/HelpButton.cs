using UnityEngine;
using System.Collections;

public class HelpButton : MonoBehaviour {
	public bool active,XSound;
	public GameObject window;
	private Animator anim;
	void Start(){
		anim = GetComponent<Animator> ();
	}
	void OnMouseOver()
	{
		if(!GameObject.Find ("Play").GetComponent<PlayButton> ().move&&!GameObject.Find("BackArrow").GetComponent<BackArrow>().move)
			anim.SetBool ("Mouse", true);
	}
	void OnMouseExit()
	{
		anim.SetBool ("Mouse", false);
	}
	void OnMouseDown() 
	{
		if (!active&&!GameObject.Find ("Play").GetComponent<PlayButton> ().move && !GameObject.Find ("BackArrow").GetComponent<BackArrow> ().move&&!GameObject.Find ("SettingsButton").GetComponent<SettingsButton> ().active) {
			GetComponent<AudioSource> ().Play ();
			window.SetActive (true);
			active = true;
		}
	}
	void Update(){
	}
}