using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SetControl : MonoBehaviour {

	public GameObject master,exit;
	public Text button;
	public string hotKey,lastKey;
	public bool active;
	public int key;
	public float time;
	public KeysWindowControl Check;
	public Sprite[] status;
	void Awake () {
		master = GameObject.Find ("Selected");
		hotKey = master.GetComponent<Selected> ().Keys [key].ToString ();
		button.text = hotKey;
	}

	void OnMouseDown()
	{
		if (!GameObject.Find ("KeysWindow").GetComponent<KeysWindowControl> ().keyActive) {
			GameObject.Find ("KeysWindow").GetComponent<KeysWindowControl> ().keyActive = true;
			active = true;
			time = Time.time;
			button.text = "New Key";
			GetComponent<AudioSource> ().Play ();
		}
	}
	void Update () {
		lastKey = hotKey;
		if (active) {
			GetComponent<SpriteRenderer> ().sprite = status [1];
			if (Input.GetKeyDown (KeyCode.Space)) {
				button.text = "Space";
				hotKey = "Space";
				master.GetComponent<Selected> ().Keys [key] = KeyCode.Space;
				Check.Check (this.gameObject, lastKey);
				active = false;
				GameObject.Find ("KeysWindow").GetComponent<KeysWindowControl> ().keyActive = false;
			} else {
				if (Input.GetKeyDown (KeyCode.Escape)) {
					button.text = "Escape";
					hotKey = "Escape";
					master.GetComponent<Selected> ().Keys [key] = KeyCode.Escape;
					Check.Check (this.gameObject, lastKey);
					active = false;
					GameObject.Find ("KeysWindow").GetComponent<KeysWindowControl> ().keyActive = false;
					GetComponent<AudioSource> ().Play ();
				} else {
					if (Input.GetKeyDown (KeyCode.LeftArrow)) {
						button.text = "LeftArrow";
						hotKey = "LeftArrow";
						master.GetComponent<Selected> ().Keys [key] = KeyCode.LeftArrow;
						Check.Check (this.gameObject, lastKey);
						active = false;
						GameObject.Find ("KeysWindow").GetComponent<KeysWindowControl> ().keyActive = false;
						GetComponent<AudioSource> ().Play ();
					} else {
						if (Input.GetKeyDown (KeyCode.RightArrow)) {
							button.text = "RightArrow";
							hotKey = "RightArrow";
							master.GetComponent<Selected> ().Keys [key] = KeyCode.RightArrow;
							Check.Check (this.gameObject, lastKey);
							active = false;
							GameObject.Find ("KeysWindow").GetComponent<KeysWindowControl> ().keyActive = false;
							GetComponent<AudioSource> ().Play ();
						} else {
							if (Input.GetKeyDown (KeyCode.UpArrow)) {
								button.text = "UpArrow";
								hotKey = "UpArrow";
								master.GetComponent<Selected> ().Keys [key] = KeyCode.UpArrow;
								Check.Check (this.gameObject, lastKey);
								active = false;
								GameObject.Find ("KeysWindow").GetComponent<KeysWindowControl> ().keyActive = false;
								GetComponent<AudioSource> ().Play ();
							} else {
								if (Input.GetKeyDown (KeyCode.DownArrow)) {
									button.text = "DownArrow";
									hotKey = "DownArrow";
									master.GetComponent<Selected> ().Keys [key] = KeyCode.DownArrow;
									Check.Check (this.gameObject, lastKey);
									active = false;
									GameObject.Find ("KeysWindow").GetComponent<KeysWindowControl> ().keyActive = false;
									GetComponent<AudioSource> ().Play ();
								} else {
									if (Input.inputString.Length > 0) {
										if (Input.inputString.ToUpper () [0] >= 'A' && Input.inputString.ToUpper () [0] <= 'Z') {
											hotKey = Input.inputString.ToUpper ();
											if (hotKey.Length > 1)
												hotKey = hotKey.Remove (1);
											button.text = hotKey;
											master.GetComponent<Selected> ().Keys [key] = (KeyCode)System.Enum.Parse (typeof(KeyCode), hotKey);
											Check.Check (this.gameObject, lastKey);
											active = false;
											GameObject.Find ("KeysWindow").GetComponent<KeysWindowControl> ().keyActive = false;
											GetComponent<AudioSource> ().Play ();
										}
									}
								}
							}
						}
					}
				}
			}
			if (Input.GetMouseButton (0) && Time.time - time > 0.2f) {
				hotKey = lastKey;
				button.text = lastKey;
				active = false;
				GameObject.Find ("KeysWindow").GetComponent<KeysWindowControl> ().keyActive = false;
				GetComponent<AudioSource> ().Play ();
			}
		} else
			GetComponent<SpriteRenderer> ().sprite = status [0];
	}
}
