using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class PlayButton : MonoBehaviour {
	private Animator anim;
	public Vector3 X,dist;
	public bool move=false;
	void Start(){
		X.x = -13f; dist.x = -0.2f;
		X.y = 2;
		X.z = -10;
		anim=GetComponent<Animator> ();
	}
	void OnMouseOver()
	{
		if(!move&&!GameObject.Find("BackArrow").GetComponent<BackArrow>().move)
			anim.SetBool ("Mouse", true);
	}
	void OnMouseExit()
	{
		anim.SetBool ("Mouse", false);
	}
	void OnMouseDown() 
	{
		if (!move && !GameObject.Find ("BackArrow").GetComponent<BackArrow> ().move&&!GameObject.Find ("SettingsButton").GetComponent<SettingsButton> ().active&&!GameObject.Find ("Help").GetComponent<HelpButton> ().active) {
			GetComponent<AudioSource> ().Play ();
			move = true;
		}
	}
	void Update()
	{
		if (move) {
			GameObject.Find ("SettingsButton").GetComponent<SpriteRenderer> ().enabled = false;
			GameObject.Find ("SettingsButton").GetComponent<BoxCollider2D> ().enabled = false;
			if (Camera.main.transform.position.x > X.x+0.1f)
				Camera.main.transform.position += dist;
			else {
				GameObject.Find ("BackArrow").GetComponent<SpriteRenderer> ().enabled = true;
				Camera.main.transform.position = X;
				GameObject.Find ("SettingsButton").GetComponent<SpriteRenderer> ().enabled = true;
				GameObject.Find ("SettingsButton").GetComponent<BoxCollider2D> ().enabled = true;
				move = false;
			}
			}
		return;
	}
}
