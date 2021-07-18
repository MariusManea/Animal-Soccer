using UnityEngine;
using System.Collections;

public class PowerUpSpawner : MonoBehaviour {

	public Vector3 V;
	public GameObject[] pwr,temp;
	public int P;
	public float time,spawn;
	public int powerS;
	public bool gasit;
	public GameObject power;

	void Start () {
		V.z = 1f;
	}

	IEnumerator Check(){
		do {
			V.x = Random.Range (-9.5f, 10f);
			V.y = Random.Range (0.7f, 6f);
			gasit = false;
			foreach (GameObject pwrup in pwr) {
				if (pwrup) {
					if (Mathf.Sqrt ((V.x - pwrup.transform.position.x) * (V.x - pwrup.transform.position.x) + (V.y - pwrup.transform.position.y) * (V.y - pwrup.transform.position.y)) < 3f) {
						gasit = true;
						break;
					}
				}
			}
			if(gasit)yield return new WaitForSeconds(0.0167f);
		} while(gasit);
		P = Random.Range (1, 180001);
		if (P > 0 && P < 10001) {
			spawn = Time.time;
			power = GameObject.Instantiate (Resources.Load ("Dead_Ball")) as GameObject;
			power.GetComponent<Dead_Ball> ().spawn = spawn;
			power.transform.position = V;
		}
		if (P > 10000 && P < 20001) {
			spawn = Time.time;
			power = GameObject.Instantiate (Resources.Load ("Bouncy_Ball")) as GameObject;
			power.GetComponent<Bouncy_Ball> ().spawn = spawn;
			power.transform.position = V;
		}
		if (P > 20000 && P < 30001) {
			spawn = Time.time;
			power = GameObject.Instantiate (Resources.Load ("Small_Ball")) as GameObject;
			power.GetComponent<Small_Ball> ().spawn = spawn;
			power.transform.position = V;
		}
		if (P > 30000 && P < 40001) {
			spawn = Time.time;
			power = GameObject.Instantiate (Resources.Load ("Big_Ball")) as GameObject;
			power.GetComponent<Big_Ball> ().spawn = spawn;
			power.transform.position = V;
		}
		if (P > 40000 && P < 50001) {
			spawn = Time.time;
			power = GameObject.Instantiate (Resources.Load ("Shrink")) as GameObject;
			power.GetComponent<Shrink> ().spawn = spawn;
			power.transform.position = V;
		}
		if (P > 50000 && P < 60001) {
			spawn = Time.time;
			power = GameObject.Instantiate (Resources.Load ("Grow")) as GameObject;
			power.GetComponent<Grow> ().spawn = spawn;
			power.transform.position = V;
		}
		if (P > 60000 && P < 70001) {
			spawn = Time.time;
			power = GameObject.Instantiate (Resources.Load ("Enemy_Freeze")) as GameObject;
			power.GetComponent<Enemy_Freeze> ().spawn = spawn;
			power.transform.position = V;
		}
		if (P > 70000 && P < 80001) {
			spawn = Time.time;
			power = GameObject.Instantiate (Resources.Load ("Self_Freeze")) as GameObject;
			power.GetComponent<Self_Freeze> ().spawn = spawn;
			power.transform.position = V;
		}
		if (P > 80000 && P < 90001) {
			spawn = Time.time;
			power = GameObject.Instantiate (Resources.Load ("Speed")) as GameObject;
			power.GetComponent<SpeedUp> ().spawn = spawn;
			power.transform.position = V;
		}
		if (P > 90000 && P < 100001) {
			spawn = Time.time;
			power = GameObject.Instantiate (Resources.Load ("Slow")) as GameObject;
			power.GetComponent<Slow> ().spawn = spawn;
			power.transform.position = V;
		}
		if (P > 100000 && P < 110001) {
			spawn = Time.time;
			power = GameObject.Instantiate (Resources.Load ("Enemy_Big_Goal")) as GameObject;
			power.GetComponent<Enemy_Big_Goal> ().spawn = spawn;
			power.transform.position = V;
		}
		if (P > 110000 && P < 120001) {
			spawn = Time.time;
			power = GameObject.Instantiate (Resources.Load ("Big_Goal")) as GameObject;
			power.GetComponent<Big_Goal> ().spawn = spawn;
			power.transform.position = V;
		}
		if (P > 120000 && P < 130001) {
			spawn = Time.time;
			power = GameObject.Instantiate (Resources.Load ("Bombs")) as GameObject;
			power.GetComponent<Bomb> ().spawn = spawn;
			power.transform.position = V;
		}
		if (P > 130000 && P < 140001) {
			spawn = Time.time;
			power = GameObject.Instantiate (Resources.Load ("Break_Enemy_Hand")) as GameObject;
			power.GetComponent<Break_Enemy_Hand> ().spawn = spawn;
			power.transform.position = V;
		}
		if (P > 140000 && P < 150001) {
			spawn = Time.time;
			power = GameObject.Instantiate (Resources.Load ("Break_Hand")) as GameObject;
			power.GetComponent<Break_Hand> ().spawn = spawn;
			power.transform.position = V;
		}
		if (P > 150000 && P < 160001) {
			spawn = Time.time;
			power = GameObject.Instantiate (Resources.Load ("Green_Wall")) as GameObject;
			power.GetComponent<Ally_Wall> ().spawn = spawn;
			power.transform.position = V;
		}
		if (P > 160000 && P < 170001) {
			spawn = Time.time;
			power = GameObject.Instantiate (Resources.Load ("Red_Wall")) as GameObject;
			power.GetComponent<Enemy_Wall> ().spawn = spawn;
			power.transform.position = V;
		}
		if (P > 170000 && P < 180001) {
			spawn = Time.time;
			power = GameObject.Instantiate (Resources.Load ("Super_Cannon")) as GameObject;
			power.GetComponent<Cannon> ().spawn = spawn;
			power.transform.position = V;
		}
		powerS++;
		int k = 0;
		foreach (GameObject pwrups in pwr) {
			if (pwrups != null) {
				temp [k] = pwrups;
				k++;
			}
		}
		temp [powerS - 1] = power;
		temp.CopyTo (pwr, 0);
		GetComponent<AudioSource> ().Play ();
		if (!gasit)
			StopCoroutine (Check ());
		yield return null;
	}
	void Update () {
		if (GameObject.Find ("Selected").GetComponent<Selected> ().powerups) {
			time = Time.timeSinceLevelLoad;
			if (time % 5 < 0.0168f && time > 0.1f && Time.timeScale == 1) {
				StartCoroutine (Check ());
			}
		}
	}
}
