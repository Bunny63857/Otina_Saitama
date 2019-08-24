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
	//設定したキャラクター情報をもとにリストから呼び出す
	void Start () {
		Instantiate(charactorList[charactorNum-1]);
	}
}
