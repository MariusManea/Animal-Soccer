using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetObstacle : MonoBehaviour {

	public GameObject master;
	public Sprite[] sprite;

	void Start () {
		master = GameObject.Find ("Selected");
	}

	void Update () {
		GetComponent<SpriteRenderer> ().sprite = sprite [master.GetComponent<Selected> ().Obstacle];
	}
}
