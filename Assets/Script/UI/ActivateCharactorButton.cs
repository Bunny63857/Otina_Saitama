using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActivateCharactorButton : MonoBehaviour
{
    private int charactorNum;
    //キャラの開放状況に合わせてボタンをアンロックする。
    void SetActivation(){
        for(var i=0;i<transform.childCount;i++){
            if(i<=charactorNum){
                transform.GetChild(i).GetComponent<Button>().interactable=true;
            }else{
                transform.GetChild(i).GetComponent<Button>().interactable=false;
            }
        }
    }
    void Awake(){
        charactorNum=PlayerPrefs.GetInt("UnlockCharactor",0);
    }
    // Start is called before the first frame update
    void Start()
    {
        SetActivation();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
