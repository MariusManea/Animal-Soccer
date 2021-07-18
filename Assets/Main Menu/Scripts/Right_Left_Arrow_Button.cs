using UnityEngine;
using System.Collections;

public class Right_Left_Arrow_Button : MonoBehaviour {
	private Animator anim1, anim2;
	public int animal=1;
	void Start(){
		anim1 = GameObject.Find ("Right_Animal").GetComponent<Animator> ();
		anim2 = GetComponent<Animator> ();
	}
	void OnMouseDown() 
	{ 
		if(!GameObject.Find("Play").GetComponent<PlayButton>().move&&!GameObject.Find("BackArrow").GetComponent<BackArrow>().move&&!GameObject.Find("Start").GetComponent<StartButton>().load)
		if (!GameObject.Find ("SettingsButton").GetComponent<SettingsButton> ().active) {
			if (animal != 1) {
				GetComponent<AudioSource> ().Play ();
				GameObject.Find ("Right_Arrow_Button2").GetComponent<Right_Right_Arrow_Button> ().animal = animal - 1;
				animal = animal - 1;
			}
			anim1.SetInteger ("Animal", animal);
		}
	}
	void Update()
	{
		if(animal==1) anim2.SetBool ("Blocked", true);
		else anim2.SetBool ("Blocked", false);
		return;
	}
}
