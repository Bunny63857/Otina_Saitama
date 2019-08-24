using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class StageSelect : MonoBehaviour {
	[SerializeField]
	int stageNum;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public void OnSelected(){
		PlayerPrefs.SetInt("Stage",stageNum);
		SceneManager.LoadScene("MainScene");
	}
}
