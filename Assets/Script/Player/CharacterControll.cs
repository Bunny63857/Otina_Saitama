using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterControll : MonoBehaviour {
    Rigidbody2D rigid;
    Vector2 startPos;
    private float speed;
    private bool IsShotGazeSet = false;
    private float gazeLength = 0;
    private Slider shotGaze;
    
	// シーン内にあるゲージを読み込む
	void Start () {
        this.rigid = GetComponent<Rigidbody2D>();
        speed = 100;
        shotGaze=GameObject.Find("ShotGaze").GetComponent<Slider>();
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0))
        {
            this.startPos = Input.mousePosition;
            IsShotGazeSet = true;
           
        }else if (Input.GetMouseButtonUp(0))
        {
            Vector2 endPos = Input.mousePosition;
            Vector2 startDirection = -1 * (endPos - startPos).normalized;
            this.rigid.AddForce(startDirection * speed);
            IsShotGazeSet = false;
        }
        if (IsShotGazeSet)
            ShotGazeSet();

        if (Input.GetKeyUp(KeyCode.Space))
        {
            this.rigid.velocity *= 0;
        }
	}
    private void FixedUpdate()
    {
        this.rigid.velocity *= 0.995f;
    }
    void ShotGazeSet()
    {
        gazeLength += 0.025f;
        if (gazeLength > 1.025f)
            gazeLength = 0;
        shotGaze.value = gazeLength;
        speed = gazeLength * 500f + 100f;
    }
}
