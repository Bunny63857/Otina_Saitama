using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Judge : MonoBehaviour
{
    private bool IsJudged=false;
    private int stageNum;
    private int unlockStage;
    // Start is called before the first frame update
    void Start()
    {
        stageNum=PlayerPrefs.GetInt("Stage",0);
        Debug.Log(stageNum);
        unlockStage=PlayerPrefs.GetInt("UnlockStage",0);
        Debug.Log(unlockStage);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    //プレイヤーか敵がフィールドから出た時に呼び出される
    void OnTriggerExit2D(Collider2D col){
        if(!IsJudged){
            Debug.Log(col+"is lose");
            IsJudged=true;
            //シーン遷移やエフェクト等もここに書く
            if(col.CompareTag("Player")){
                SceneManager.LoadScene("GameOver");
            }
            if(col.CompareTag("Enemy")){
                if(stageNum>unlockStage){
                    PlayerPrefs.SetInt("UnlockStage",stageNum);
                    PlayerPrefs.SetInt("UnlockCharactor",stageNum);
                }
                SceneManager.LoadScene("GameClear");
            }
        }
    }
}
