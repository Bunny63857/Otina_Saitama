using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ActivateStageButton : MonoBehaviour
{
    private int stageNum;
    void Awake(){
        stageNum=PlayerPrefs.GetInt("UnlockStage",0);
    }
    // Start is called before the first frame update
    void Start()
    {
        SetActivation();
    }
    void SetActivation(){
        for(var i=0;i<transform.childCount;i++){
            if(i<=stageNum){
                transform.GetChild(i).GetComponent<Button>().interactable=true;
            }else{
                transform.GetChild(i).GetComponent<Button>().interactable=false;
            }
        }
    }
}
