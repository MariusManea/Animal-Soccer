using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class StartButton : MonoBehaviour {
	private Animator anim;
	public bool load, loading;
	public float time;
	public GameObject info;
	void Start(){
		load = false;
		anim = GetComponent<Animator> ();
	}
	void OnMouseOver()
	{
		if(!GameObject.Find("Play").GetComponent<PlayButton>().move&&!GameObject.Find("BackArrow").GetComponent<BackArrow>().move)
			anim.SetBool ("Mouse", true);
	}
	void OnMouseExit()
	{
		anim.SetBool ("Mouse", false);
	}
	void OnMouseDown (){
		if (!load) {
			info.SetActive (true);
			this.GetComponent<SpriteRenderer> ().enabled = false;
			//Application.LoadLevel (Application.loadedLevel + 1);
			if (!GameObject.Find ("Play").GetComponent<PlayButton> ().move && !GameObject.Find ("BackArrow").GetComponent<BackArrow> ().move) {
				GetComponent<AudioSource> ().Play ();
				if (!GameObject.Find ("SettingsButton").GetComponent<SettingsButton> ().active) {
					load = true;
					time = Time.time;
					GameObject.Find ("Left_Animal").GetComponent<LeftPick> ().sources [GameObject.Find ("Selected").GetComponent<Selected> ().Left_Animal-1].Play ();
					GameObject.Find ("Right_Animal").GetComponent<RightPick> ().sources [GameObject.Find ("Selected").GetComponent<Selected> ().Right_Animal-1].Play ();
				}
			}
		}
	}

	void Update(){
		if (load&&!loading) {
			StartCoroutine (LoadScene());
			loading = true;
		}
	}
	IEnumerator LoadScene(){
		AsyncOperation async = SceneManager.LoadSceneAsync (1, LoadSceneMode.Single);
		async.allowSceneActivation = false;
		while (!async.isDone && Time.time - time<2)
			yield return null;
		async.allowSceneActivation = true;
	}
}
