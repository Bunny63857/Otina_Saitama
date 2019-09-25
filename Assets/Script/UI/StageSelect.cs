using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class StageSelect : MonoBehaviour {
	[SerializeField]
	int stageNum;
	private AudioSource sound;
	// Use this for initialization
	void Start () {
		sound=GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public void OnSelected(){
		PlayerPrefs.SetInt("Stage",stageNum);
		sound.PlayOneShot(sound.clip);
		StartCoroutine(ChangeScene());
	}
	IEnumerator ChangeScene(){
		yield return new WaitForSeconds(1.0f);
		SceneManager.LoadScene("MainScene");
	}
}
