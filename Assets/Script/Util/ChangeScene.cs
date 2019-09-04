using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    //インスペクタで指定した名前のシーンに遷移する
	[SerializeField]
	private string sceneName;
	
	public void OnClicked(){
		SceneManager.LoadScene(sceneName);
	}
}
