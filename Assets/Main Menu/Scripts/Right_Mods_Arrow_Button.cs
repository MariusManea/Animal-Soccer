using UnityEngine;
using System.Collections;

public class Right_Mods_Arrow_Button : MonoBehaviour {
	
	private Animator anim1, anim2;
	public int mode=1;
	void Start(){
		anim1 = GameObject.Find ("Mods").GetComponent<Animator> ();
		anim2 = GetComponent<Animator> ();
	}
	void OnMouseDown() 
	{ 
		if(!GameObject.Find("Play").GetComponent<PlayButton>().move&&!GameObject.Find("BackArrow").GetComponent<BackArrow>().move&&!GameObject.Find("Start").GetComponent<StartButton>().load)
		if (!GameObject.Find ("SettingsButton").GetComponent<SettingsButton> ().active) {
			if (mode != 3) {
				GetComponent<AudioSource> ().Play ();
				GameObject.Find ("Mods_Arrow_Button").GetComponent<Left_Mods_Arrow_Button> ().mode = mode + 1;
				mode = mode + 1;
			}
			anim1.SetInteger ("Mode", mode);
		}
	}
	void Update()
	{
		if(mode==3) anim2.SetBool ("Blocked", true);
		else anim2.SetBool ("Blocked", false);
		return;
	}
}
