using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterSelect : MonoBehaviour {
	[SerializeField]
	int CharactorNum;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public void OnClicked(){
		PlayerPrefs.SetInt("Charactor",CharactorNum);
		SceneManager.LoadScene("StageSelectScene");
	}
}
