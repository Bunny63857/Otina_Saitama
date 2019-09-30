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
    private float CharactorStopThreshold=1f;
    private bool IsAttacked=false;
    // private MoverAgent agent;
    [SerializeField]
    private List<GameObject> gimmickList;
    private enum StateEventID{
        Idle,
        Attack,
    }
    private void Awake(){
        stateMachine=new ImtStateMachine<EnemyController>(this);
        stateMachine.AddTransition<IdleState,AttackState>((int)StateEventID.Attack);
        stateMachine.AddTransition<AttackState,IdleState>((int)StateEventID.Idle);
        stateMachine.SetStartState<IdleState>();
        // agent = GameObject.FindGameObjectWithTag("Enemy").GetComponent<MoverAgent>();
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
            Context.StartCoroutine(Context.Attack());
        }
        protected override void Update(){
            Context.speed=Context.rigid.velocity.magnitude;
            //コルーチンの処理が終わるまでは到達しない
            if(Context.speed<Context.CharactorStopThreshold&&Context.IsAttacked){
                Context.player.GetComponent<CharacterControll>().EnableMove();
                Context.DisableMove();
                Context.IsAttacked=false;
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
        stateMachine.Update();
        //時間ないので筋肉解決
        for(int i=0;i<gimmickList.Count;i++){
            if(gimmickList.Count==1){
                Instantiate(gimmickList[i],new Vector2(Random.Range(-5,-1),Random.Range(-3,3)),Quaternion.identity);
                Instantiate(gimmickList[i],new Vector2(Random.Range(1,5),Random.Range(-3,3)),Quaternion.identity);
            }else if(i%2==0){
                Instantiate(gimmickList[i],new Vector2(Random.Range(-5,-1),Random.Range(-3,3)),Quaternion.identity);
            }else if(i%2==1){
                Instantiate(gimmickList[i],new Vector2(Random.Range(1,5),Random.Range(-3,3)),Quaternion.identity);
            }
        }
        
    }

    private void FixedUpdate()
    {
        dir=player.transform.position-transform.position;
        stateMachine.Update();
        this.rigid.velocity *= 0.995f;
    }
    IEnumerator Attack(){
        yield return new WaitForSeconds(3);
        rigid.AddForce(dir*Random.Range(500,100));
        // Debug.Log(agent.controlSignal);
        // rigid.AddForce(agent.controlSignal*Random.Range(3000,1000));
        IsAttacked=true;
    }
}
