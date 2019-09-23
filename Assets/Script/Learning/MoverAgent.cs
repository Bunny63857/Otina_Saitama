// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// using UnityEngine.UI;
// using IceMilkTea.Core;
// using MLAgents;

// public class MoverAgent : Agent
// {
//     public JudgeLearn judgelearn;
//     Rigidbody2D rBody;
//     Vector2 startPos;
//     private float speed;
//     private bool IsShotGazeSet = false;
//     private float gazeLength = 0;
//     private Slider shotGaze;
    
// 	// シーン内にあるゲージを読み込む
// 	void Start ()
//     {
//         judgelearn = GameObject.FindGameObjectWithTag("Stage").GetComponent<JudgeLearn>();
//         rBody = GetComponent<Rigidbody2D>();
//         speed = 100;

// 	}
//     public Transform Target;
//     public override void AgentReset()
//     {
//         if (judgelearn.loser == "MoverAgent")
//         {
//             // If the Agent fell, zero its momentum
//             // this.rBody.angularVelocity = Vector2.zero;
//             judgelearn.loser = "";
//             this.rBody.velocity = Vector2.zero;
//             this.rBody.position = new Vector2(0, -0.89f);
//         }

//         // Move the target to a new spot
//         Target.position = new Vector2(Random.value * 4 - 2,
//                                       Random.value * 4 - 2);
//     }
//     public override void CollectObservations()
//     {
//         // Target and Agent positions
//         AddVectorObs(Target.position);
//         AddVectorObs(this.transform.position);

//         // Agent velocity
//         AddVectorObs(rBody.velocity.x);
//         AddVectorObs(rBody.velocity.y);
//     }
//     public override void AgentAction(float[] vectorAction, string textAction)
//     {
//         // Actions, size = 2
//         Vector2 controlSignal = Vector2.zero;
//         controlSignal.x = vectorAction[0];
//         controlSignal.y = vectorAction[1];
//         rBody.AddForce(controlSignal * speed);

//         // Reached target
//         if (judgelearn.loser == "Target")
//         {
//             judgelearn.loser = "";
//             Target.position = new Vector2(Random.value * 4 - 2,
//                                         Random.value * 4 - 2);
//             this.transform.position = new Vector2(0, -0.89f);
//             SetReward(1.0f);
//             Done();
//         }

//         // Fell off platform
//         if (judgelearn.loser == "MoverAgent")
//         {
//             judgelearn.loser = "";
//             Target.position = new Vector2(Random.value * 4 - 2,
//                                         Random.value * 4 - 2);
//             this.transform.position = new Vector2(0, -0.89f);
//             Done();
//         }
//     }}
