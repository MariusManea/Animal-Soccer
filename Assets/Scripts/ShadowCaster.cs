using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShadowCaster : MonoBehaviour {

	public RaycastHit2D hit;
	public Vector3 newPos,rayPos,sScale;
	public GameObject ball;
	public LayerMask layerMask;

	void Start () {
		ball = GameObject.Find ("Ball");
		sScale = this.transform.localScale;
	}

	void Update () {
		if (ball.GetComponent<Ball> ().big)
			sScale.x = 2.5f;
		else if (ball.GetComponent<Ball> ().small)
			sScale.x = 1.25f;
		else
			sScale.x = 2f;
		this.transform.localScale = sScale;
		rayPos = ball.transform.position;
		hit = Physics2D.Raycast (rayPos, -Vector2.up, 1000f, layerMask);
		newPos = new Vector3 (ball.transform.position.x , hit.point.y, this.transform.position.z);
		this.transform.position = newPos;
	}
}
