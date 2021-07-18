using UnityEngine;
using System.Collections;

public class Left_Right_Arrow_Button : MonoBehaviour {
	private Animator anim1, anim2;
	public int animal=1;
	void Start(){
		anim1 = GameObject.Find ("Left_Animal").GetComponent<Animator> ();
		anim2 = GetComponent<Animator> ();
	}
	void OnMouseDown() 
	{ 
		if(!GameObject.Find("Play").GetComponent<PlayButton>().move&&!GameObject.Find("BackArrow").GetComponent<BackArrow>().move&&!GameObject.Find("Start").GetComponent<StartButton>().load)
		if (!GameObject.Find ("SettingsButton").GetComponent<SettingsButton> ().active) {
			if (animal != 15) {
				GetComponent<AudioSource> ().Play ();
				GameObject.Find ("Left_Arrow_Button").GetComponent<Left_Left_Arrow_Button> ().animal = animal + 1;
				animal = animal + 1;
			}
			anim1.SetInteger ("Animal", animal);
		}
	}
	void Update()
	{
		if(animal==15) anim2.SetBool ("Blocked", true);
				 else anim2.SetBool ("Blocked", false);
		return;
	}
}
