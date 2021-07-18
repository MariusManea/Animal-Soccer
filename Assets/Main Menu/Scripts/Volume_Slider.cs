using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Volume_Slider : MonoBehaviour {

	public GameObject master;
	public Transform lim_0,lim_100;
	public Vector3 position,last_mouse_position;
	public float maximD,actualD,y,yp,value;
	void Start () {
		master = GameObject.Find ("Selected");
		maximD = Vector3.Distance (lim_0.position, lim_100.position);
		if (y == 440)
			this.transform.position = new Vector3 (master.GetComponent<Selected> ().SVolume * maximD + lim_0.position.x, yp, -9);
		else
			this.transform.position = new Vector3 (master.GetComponent<Selected> ().MVolume * maximD + lim_0.position.x, yp, -9);
	}

	void OnMouseOver(){
		if(!Input.GetMouseButtonDown(0))
			last_mouse_position = Input.mousePosition;
	}
	void OnMouseDown(){
		GameObject.Find ("Sounds").GetComponent<AudioSource> ().Play ();
	}

	void OnMouseDrag(){
		Cursor.visible = false;
		position = this.transform.position;
		position.x -= (last_mouse_position.x - Input.mousePosition.x) / 32.5f;
		if (position.x > lim_0.position.x && position.x < lim_100.position.x) {
			this.transform.position = position;
			last_mouse_position = Input.mousePosition;
		} else if (position.x <= lim_0.position.x) {
			last_mouse_position = Input.mousePosition;
			this.transform.position = lim_0.position;
		} else if (position.x >= lim_0.position.x) {
			last_mouse_position = Input.mousePosition;
			this.transform.position = lim_100.position;
		}
	}
	void OnMouseUp(){
		if (y == 440)
			GetComponent<AudioSource> ().Play ();
		CursorControl.SetLocalCursorPos (new Vector2 (172+1.53f*value*100,y));
		Cursor.visible = true;
	}

	void Update () {
		actualD = Vector3.Distance (lim_0.position, this.transform.position);
		value = actualD / maximD;
		if (y == 440)
			master.GetComponent<Selected> ().SVolume = value;
		else
			master.GetComponent<Selected> ().MVolume = value;
	}

}
