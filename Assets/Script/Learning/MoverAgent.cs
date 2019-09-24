using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using IceMilkTea.Core;
using MLAgents;
using System;

public class MoverAgent : Agent
{
    // public JudgeLearn judgelearn;
    Rigidbody2D rBody;
    Vector2 startPos;
    private float speed;
    private bool IsShotGazeSet = false;
    private float gazeLength = 0;
    private Slider shotGaze;
    public Vector2 controlSignal;
    
    public Transform Target;

	void Awake ()
    {
        // judgelearn = GameObject.FindGameObjectWithTag("Stage").GetComponent<JudgeLearn>();
        rBody = GetComponent<Rigidbody2D>();
                // Debug.Log("start",rBody);
        speed = 100;
        Target = GameObject.FindGameObjectWithTag("Enemy").transform;
	}

    //learning
    // public override void AgentReset()
    // {
    //     if (judgelearn.loser == "MoverAgent")
    //     {
    //         // If the Agent fell, zero its momentum
    //         // this.rBody.angularVelocity = Vector2.zero;
    //         judgelearn.loser = "";
    //         this.rBody.velocity = Vector2.zero;
    //         this.transform.position = new Vector2(-5, 0);
    //     }

    //     // Move the target to a new spot
    //       Target.position = new Vector2(Random.Range(4.5f,-2.5f),Random.Range(3,-1.5f));
    // }

    public override void CollectObservations()
    {
      //相手と自分の情報を送って判断
        // Target and Agent positions
        AddVectorObs(Target.position);
        AddVectorObs(this.transform.position);
        // Debug.Log(rBody);

        // Agent velocity
        AddVectorObs(rBody.velocity.x);
        AddVectorObs(rBody.velocity.y);
    }
    public override void AgentAction(float[] vectorAction, string textAction)
    {
      //定めたフレームごとに呼び出される(今は1秒に一回)
        controlSignal = Vector2.zero;
        controlSignal.x = vectorAction[0];
        controlSignal.y = vectorAction[1];

      //Learning

      // Debug.Log(controlSignal);
      // Vector2 controlSignal = Vector2.zero;
      // controlSignal.x = vectorAction[0];
      // controlSignal.y = vectorAction[1];
      // Debug.Log(controlSignal);
      // rBody.AddForce(controlSignal * speed);

      // if (judgelearn.loser == "Target")
      // {
      //     judgelearn.loser = "";
      //     Target.position = new Vector2(Random.Range(4.5f,-2.5f),Random.Range(3,-1.5f));
      //     this.rBody.velocity = Vector2.zero;
      //     this.transform.position = new Vector2(-5, 0);
      //     SetReward(1.0f);
      //     Done();
      // }

      // if (judgelearn.loser == "MoverAgent")
      // {
      //     judgelearn.loser = "";
      //     Target.position = new Vector2(Random.Range(4.5f,-2.5f),Random.Range(3,-1.5f));
      //     this.rBody.velocity = Vector2.zero;
      //     this.transform.position = new Vector2(-5, 0);
      //     SetReward(-1.0f);
      //     Done();
      // }
    }
}
