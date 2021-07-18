using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class LoadingGame : MonoBehaviour {

	public GameObject Play,Help,Exit,Settings;
	public bool loading,ready,finish;
	public Image bar;
	public float value,div,time;
	public Color colorValue;
	public Text text;

	void Start () {
		colorValue = new Color (1f, 1f, 1f, 0f);
		Settings.SetActive (false);
		Play.GetComponent<SpriteRenderer> ().color = colorValue;
		Help.GetComponent<SpriteRenderer> ().color = colorValue;
		Exit.GetComponent<SpriteRenderer> ().color = colorValue;
		Play.GetComponent<BoxCollider2D> ().enabled = false;
		Help.GetComponent<BoxCollider2D> ().enabled = false;
		Exit.GetComponent<BoxCollider2D> ().enabled = false;
		bar = GetComponent<Image> ();
		if (Time.time < 2f) {
			loading = true;
			bar.fillAmount = 0f;
		}
	}

	void Update () {
		if (bar.fillAmount == 1f&&!ready) {
			GameObject.Find ("Title").GetComponent<AudioSource> ().Play ();
			loading = false;
			ready = true;
		}
		if (ready) {
			bar.enabled = false;
			GameObject.Find ("LoadingBorder").GetComponent<Image> ().enabled = false;
			text.text = "";
			colorValue.a += Time.deltaTime;
			Play.GetComponent<SpriteRenderer> ().color = colorValue;
			Help.GetComponent<SpriteRenderer> ().color = colorValue;
			Exit.GetComponent<SpriteRenderer> ().color = colorValue;
			if (colorValue.a >= 1f) {
				ready = false;
				finish = true;
			}
			if (finish) {
				Play.GetComponent<BoxCollider2D> ().enabled = true;
				Help.GetComponent<BoxCollider2D> ().enabled = true;
				Exit.GetComponent<BoxCollider2D> ().enabled = true;
				Settings.SetActive (true);
				Destroy (this.transform.parent.gameObject);

			}
		}
		if (loading) {
			if (text.text == "Loading..."&&Time.time-time>0.44f)
				text.text = "Loading";
			if (Time.time - time > 0.44f) {
				text.text = text.text + ".";
				time = Time.time;
			}
			bar.fillAmount = value;
			div = Random.Range (2f, 10f);
			value += Time.deltaTime/div;
		}
	}
	void OnApplicationPause(bool Paused)
	{
		if (Paused) {
			Application.runInBackground = true;
		} else
			Application.runInBackground = false;
	}
}
