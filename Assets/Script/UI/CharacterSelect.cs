using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterSelect : MonoBehaviour {
	[SerializeField]
	int CharactorNum;
	private AudioSource sound;
	// Use this for initialization
	void Start () {
		sound=GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public void OnClicked(){
		sound.PlayOneShot(sound.clip);
		PlayerPrefs.SetInt("Charactor",CharactorNum);
		StartCoroutine(ChangeScene());
	}
	IEnumerator ChangeScene(){
		yield return new WaitForSeconds(1.0f);
		SceneManager.LoadScene("StageSelectScene");
	}
}
