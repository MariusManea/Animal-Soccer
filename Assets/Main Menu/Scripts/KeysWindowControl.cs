using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class KeysWindowControl : MonoBehaviour {

	public GameObject exit, switcher, master;
	public bool keyActive;
	public GameObject[] Buttons;

	void Start () {
		master = GameObject.Find ("Selected");
	}
	public void Check(GameObject target, string button)
	{
		foreach (GameObject other in Buttons) {
			if (other != target) {
				if (other.GetComponent<SetControl> ().hotKey == target.GetComponent<SetControl> ().hotKey) {
					target.GetComponent<SetControl> ().hotKey = other.GetComponent<SetControl> ().hotKey;
					other.GetComponent<SetControl> ().hotKey = button;
					master.GetComponent<Selected> ().Keys [other.GetComponent<SetControl> ().key] = (KeyCode)System.Enum.Parse (typeof(KeyCode), other.GetComponent<SetControl> ().hotKey);
					master.GetComponent<Selected> ().Keys [target.GetComponent<SetControl> ().key] = (KeyCode)System.Enum.Parse (typeof(KeyCode), target.GetComponent<SetControl> ().hotKey);
					target.GetComponent<SetControl> ().button.text = target.GetComponent<SetControl> ().hotKey;
					other.GetComponent<SetControl> ().button.text = other.GetComponent<SetControl> ().hotKey;
				}
			}
		}
	}
	void Update () {
		if (keyActive) {
			exit.GetComponent<CapsuleCollider2D> ().enabled = false;
			switcher.GetComponent<BoxCollider2D> ().enabled = false;
		} else {
			exit.GetComponent<CapsuleCollider2D> ().enabled = true;
			switcher.GetComponent<BoxCollider2D> ().enabled = true;
		}
	}
}
