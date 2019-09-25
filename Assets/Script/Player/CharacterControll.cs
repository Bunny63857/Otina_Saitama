using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using IceMilkTea.Core;

public class CharacterControll : MonoBehaviour {
    Rigidbody2D rigid;
    Vector2 startPos;
    private float speed;
    private bool IsShotGazeSet = false;
    private float gazeLength = 0;
    private Slider shotGaze;
    private ImtStateMachine<CharacterControll> stateMachine;
    private float CharactorStopThreshold=1f;
    private GameObject enemy;
    [SerializeField]
    private GameObject hitEffect;
    private AudioSource sound;
    private enum StateEventID{
        Idle,
        Active,
    }
    // [SerializeField]
    private LineRenderer direction;
    private Vector2 currentForce;
    private Vector2 dragStart = Vector2.zero; 
    // private GameObject prefabObject;

    private void Awake(){
        stateMachine=new ImtStateMachine<CharacterControll>(this);
        stateMachine.AddTransition<IdleState,ActiveState>((int)StateEventID.Active);
        stateMachine.AddTransition<ActiveState,IdleState>((int)StateEventID.Idle);
        stateMachine.SetStartState<ActiveState>();
    }
    private class IdleState:ImtStateMachine<CharacterControll>.State{
        //editorに怒られるけど問題なく動く
        protected override void Update(){
            if(Input.GetKeyDown(KeyCode.Z)){
                Context.stateMachine.SendEvent((int)StateEventID.Active);
            }
            var speed= Context.rigid.velocity.magnitude;
            if(speed<Context.CharactorStopThreshold){
                Context.rigid.velocity=new Vector2();
                Context.enemy.GetComponent<EnemyController>().EnableMove();
            }
        }
    }
    private class ActiveState:ImtStateMachine<CharacterControll>.State{
        //プレイヤーを動かす処理
        private float arrowSize = 4;
        private float maxMagnitude = 200;
        protected override void Update(){
            if (Input.GetMouseButtonDown(0))
            {
                Context.startPos = Input.mousePosition;
                Context.IsShotGazeSet = true;
                Context.direction.enabled = true;
                Context.direction.SetPosition(0, Context.rigid.position);
                Context.direction.SetPosition(1, Context.rigid.position);

            }else if (Input.GetMouseButtonUp(0))
            {
                Context.direction.enabled = false;
                Vector2 endPos = Input.mousePosition;
                Vector2 startDirection = -1 * (endPos - Context.startPos).normalized;
                Context.rigid.AddForce(startDirection * Context.speed);
                Context.IsShotGazeSet = false;
                Context.stateMachine.SendEvent((int)StateEventID.Idle);

            }else if(Input.GetMouseButton(0)){
                //drag action
                Vector2 nowPos = Input.mousePosition;
                Context.currentForce =Context.startPos-nowPos;
                if (Context.currentForce.magnitude > this.maxMagnitude){
                    Context.currentForce *= this.arrowSize / Context.currentForce.magnitude;
                    Context.direction.SetPosition(1, Context.rigid.position + Context.currentForce);
                }else{
                    Context.direction.SetPosition(1, Context.rigid.position + Context.currentForce/(maxMagnitude/arrowSize));
                }
                Context.direction.SetPosition(0, Context.rigid.position);    
                       
            }
            if (Context.IsShotGazeSet)
                Context.ShotGazeSet();
            if (Input.GetKeyUp(KeyCode.Space))
            {
                Context.rigid.velocity *= 0;
            }
        }
    }
	// シーン内にあるゲージを読み込む
	private void Start () {
        stateMachine.Update();
        this.rigid = GetComponent<Rigidbody2D>();
        speed = 100;
        shotGaze=GameObject.Find("ShotGaze").GetComponent<Slider>();
        enemy=GameObject.FindGameObjectWithTag("Enemy");
        sound=GetComponent<AudioSource>();
        //インスタンス生成
        direction = Resources.Load("Direction", typeof(LineRenderer)) as LineRenderer;
        LineRenderer childObject = Instantiate(direction, rigid.position, Quaternion.identity);
        childObject.transform.parent = this.transform;
        direction = childObject;
        // direction.enabled = false;
	}

    //他クラスからステートをいじりたい
	public void EnableMove(){
        stateMachine.SendEvent((int)StateEventID.Active);
    }
    public void DisableMove(){
        stateMachine.SendEvent((int)StateEventID.Idle);
    }
	// Update is called once per frame
    /* 
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
	}*/
    // void Update(){
    //     Vector2 position = Input.mousePosition;
    //     Debug.Log(position);

    // }
    private void FixedUpdate()
    {
        stateMachine.Update();
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
    void OnCollisionEnter2D(Collision2D col){
        if(col.gameObject.tag=="Enemy"){
            foreach(ContactPoint2D point in col.contacts){
                GameObject effect = Instantiate (hitEffect) as GameObject;
                effect.transform.position = (Vector3)point.point;
            }
            sound.PlayOneShot(sound.clip);
        }
    }
}
