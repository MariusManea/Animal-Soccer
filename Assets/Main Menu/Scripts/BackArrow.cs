using UnityEngine;
using System.Collections;

public class BackArrow : MonoBehaviour {
	private Animator anim;
	public Vector3 X,dist;
	public bool move=false;
	void Start(){
		X.x = 0.4f; dist.x = 0.2f;
		X.y = 2;
		X.z = -10;
		anim=GetComponent<Animator> ();
	}
	void OnMouseOver()
	{
		if(!GameObject.Find("Play").GetComponent<PlayButton>().move&&!move)
			anim.SetBool ("Mouse", true);
	}
	void OnMouseExit()
	{
		anim.SetBool ("Mouse", false);
	}
	void OnMouseDown() 
	{
		if (!GameObject.Find ("Play").GetComponent<PlayButton> ().move && !move && !GameObject.Find ("Start").GetComponent<StartButton> ().load) {
			GetComponent<AudioSource> ().Play ();
			if (!GameObject.Find ("SettingsButton").GetComponent<SettingsButton> ().active)
				move = true;
		}
	}
	void Update()
	{
		if (move) {
			GameObject.Find ("BackArrow").GetComponent<SpriteRenderer> ().enabled = false;
			GameObject.Find ("SettingsButton").GetComponent<SpriteRenderer> ().enabled = false;
			GameObject.Find ("SettingsButton").GetComponent<BoxCollider2D> ().enabled = false;
			if (Camera.main.transform.position.x < X.x-0.1f)
				Camera.main.transform.position += dist;
			else {
				Camera.main.transform.position = X;
				GameObject.Find ("SettingsButton").GetComponent<SpriteRenderer> ().enabled = true;
				GameObject.Find ("SettingsButton").GetComponent<BoxCollider2D> ().enabled = true;
				move = false;
			}
		}
		return;
	}
}
