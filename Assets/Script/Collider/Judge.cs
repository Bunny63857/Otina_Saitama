using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Judge : MonoBehaviour
{
    private bool IsJudged=false;
    // Start is called before the first frame update
    void Start()
    {
        
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
            
        }
    }
}
