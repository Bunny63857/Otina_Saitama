using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using IceMilkTea.Core;

public class EnemyController : MonoBehaviour
{
    private GameObject player;
    private Vector2 dir;
    private Rigidbody2D rigid;
    private float speed;
    private ImtStateMachine<EnemyController> stateMachine;
    private float CharactorStopThreshold=2f;
    private enum StateEventID{
        Idle,
        Attack,
    }
    private void Awake(){
        stateMachine=new ImtStateMachine<EnemyController>(this);
        stateMachine.AddTransition<IdleState,AttackState>((int)StateEventID.Attack);
        stateMachine.AddTransition<AttackState,IdleState>((int)StateEventID.Idle);
        stateMachine.SetStartState<IdleState>();
    }
    private class IdleState:ImtStateMachine<EnemyController>.State{
        //何もしない
        protected override void Update(){
        }
    }
    //攻撃後プレイヤーのステートを更新する
    private class AttackState:ImtStateMachine<EnemyController>.State{
        protected override void Enter()
        {
            Context.rigid.AddForce(Context.dir);
        }
        protected override void Update(){
            Context.speed=Context.rigid.velocity.magnitude;
            if(Context.speed<Context.CharactorStopThreshold){
                Context.player.GetComponent<CharacterControll>().EnableMove();
                Context.DisableMove();
            }
        }
    }
    //他クラスからステートをいじりたい
	public void EnableMove(){
        stateMachine.SendEvent((int)StateEventID.Attack);
    }
    public void DisableMove(){
        stateMachine.SendEvent((int)StateEventID.Idle);
    }
    // Start is called before the first frame update
    void Start()
    {
        player=GameObject.FindGameObjectWithTag("Player");
        rigid=GetComponent<Rigidbody2D>();
        dir=player.transform.position-transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        dir=player.transform.position-transform.position;
    }
}
