using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XSettingsButton : MonoBehaviour {
	public GameObject window;

	void Start () {
		
	}

	void Update () {
		
	}

	void OnMouseEnter()
	{
		
	}
	void OnMouseExit()
	{
		
	}
	void OnMouseDown() 
	{
		GameObject.Find ("SettingsButton").GetComponent<SettingsButton> ().XSound = true;;
		window.SetActive (false);
		if (window.name == "HelpWindows")
			GameObject.Find("Help").GetComponent<HelpButton> ().active = false;
		else {
			GameObject.Find ("SettingsButton").GetComponent<SettingsButton> ().active = false;
			GameObject.Find ("SettingsButton").GetComponent<SpriteRenderer> ().enabled = true;
			GameObject.Find ("SettingsButton").GetComponent<BoxCollider2D> ().enabled = true;
		}
	}
}
