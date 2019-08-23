using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetCharactor : MonoBehaviour {
	int charactorNum;
	[SerializeField]
	private List<GameObject> charactorList;
	//スタート関数の前に呼び出される
	void Awake(){
		charactorNum=PlayerPrefs.GetInt("Charactor",0);
	}
	// Use this for initialization
	void Start () {
		Debug.Log(charactorNum);
		Instantiate(charactorList[charactorNum-1]);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
