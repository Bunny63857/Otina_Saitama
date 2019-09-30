using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleScene : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0)
        {
        Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Ended)
            {
                SceneManager.LoadScene("CharactorSelectScene");
            }
        }
        else if(Input.GetKeyDown(KeyCode.Z)){
            SceneManager.LoadScene("CharactorSelectScene");
        }
    }
}
