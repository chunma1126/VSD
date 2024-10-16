using System;
using System.Collections;
using UnityEngine;

public class Player : MonoBehaviour
{
    private PlayerStateMachine StateMachine;
    
    public InputSO input;
        
    public float moveSpeed;
    public float dodgeSpeed;
    
    [Header("Attack Info")] 
    public LayerMask whatIsEnemy;
    public Vector2[] attackMovement;//x
    public float attackDuration;
    public int comboCounter;
    
    
    public bool canChangeState = true;
    
    public Animator Animator { get; private set; }

    public PlayerMovement Movement { get; private set; }

    public VFXPlayer VFXPlayer { get; private set; }


    private void Awake()
    {
        Animator = GetComponentInChildren<Animator>();
        Movement = GetComponent<PlayerMovement>();
        VFXPlayer = GetComponentInChildren<VFXPlayer>();
        
        StateMachine = new PlayerStateMachine();
        StateMachine.AddState(PlayerStateEnum.Idle , new PlayerIdleState(this ,StateMachine ,"Idle"));
        StateMachine.AddState(PlayerStateEnum.Move , new PlayerMoveState(this ,StateMachine ,"Move"));
        StateMachine.AddState(PlayerStateEnum.Attack , new PlayerAttackState(this,StateMachine,"Attack"));
        StateMachine.AddState(PlayerStateEnum.Dodge , new PlayerDodgeState(this,StateMachine,"Dodge"));
        
        input.OnAttackEvent += ()=>
        {
            if(!canChangeState)return;
            
            StateMachine.ChangeState(PlayerStateEnum.Attack);
        };
        input.OnDodgeEvent += ()=>
        {
            if(!canChangeState)return;
            
            StateMachine.ChangeState(PlayerStateEnum.Dodge);
        };
    }
    
    

    private void Start()
    {
        StateMachine.Initialize(PlayerStateEnum.Idle);
    }

    private void Update()
    {
        StateMachine.currentState.Update();
    }
    
    public Vector2 GetMoveInput()
    {
        return input.MoveInput;
    }
    
    public void AnimationEndTrigger()
    {
        StateMachine.currentState.AnimationTriggerCalled();
    }

    public void PlaySlashEffect()
    {
        VFXPlayer.PlaySlashEffect(comboCounter);
    }
    
    public Coroutine StartDelayCallback(float time, Action Callback)
    {
        return StartCoroutine(DelayCoroutine(time, Callback));
    }
   
    private IEnumerator DelayCoroutine(float time, Action Callback)
    {
        yield return new WaitForSeconds(time);
        Callback?.Invoke();
    }
    
     
    
    
    /*private void LookAtMouse()
    {
        Vector3 mousePosition = input.GetMouseWorldPosition();
        Vector3 direction = (mousePosition - transform.position).normalized;  
        
        Quaternion lookTarget = Quaternion.LookRotation(direction);
        transform.rotation = Quaternion.Slerp(transform.rotation, lookTarget, Time.deltaTime * 10);
    }*/
    
}
