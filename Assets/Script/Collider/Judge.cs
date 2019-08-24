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
    void OnTriggerExit2D(Collider2D col){
        if(!IsJudged){
            Debug.Log(col+"is lose");
            IsJudged=true;
        }
    }
}
