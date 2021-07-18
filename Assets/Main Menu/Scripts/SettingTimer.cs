using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingTimer : MonoBehaviour {

	public GameObject master;
	public Sprite[] minutes;
	void Start () {
		master = GameObject.Find ("Selected");
	}

	void Update () {
		GetComponent<SpriteRenderer> ().sprite = minutes [Mathf.FloorToInt(master.GetComponent<Selected> ().initial_time) / 60 - 1];
	}
}
