using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetStage : MonoBehaviour
{
    private int stageNum;
    [SerializeField]
	private List<GameObject> stageList;
    void Awake(){
        stageNum=PlayerPrefs.GetInt("Stage",0);
    }
    // Start is called before the first frame update
    void Start()
    {
        Instantiate(stageList[stageNum-1]);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
