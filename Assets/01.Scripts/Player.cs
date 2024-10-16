using System;
using System.Collections;
using UnityEngine;

public class Player : MonoBehaviour
{
    private PlayerStateMachine StateMachine;
    
    public InputSO input;
        
    public float moveSpeed;
    
    [Header("Attack Info")] 
    public LayerMask whatIsEnemy;
    public Vector2[] attackMovement;//x
    public float attackDuration;
    
    public Animator Animator { get; private set; }

    public PlayerMovement Movement { get; private set; }

    private void Awake()
    {
        Animator = GetComponentInChildren<Animator>();
        Movement = GetComponent<PlayerMovement>();
        
        StateMachine = new PlayerStateMachine();
        StateMachine.AddState(PlayerStateEnum.Idle , new PlayerIdleState(this ,StateMachine ,"Idle"));
        StateMachine.AddState(PlayerStateEnum.Move , new PlayerMoveState(this ,StateMachine ,"Move"));
        StateMachine.AddState(PlayerStateEnum.Attack , new PlayerAttackState(this,StateMachine,"Attack"));
        
        input.OnAttackEvent += EnterAttackState;
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

    public void EnterAttackState()
    {
        StateMachine.ChangeState(PlayerStateEnum.Attack);
    }

    public void AnimationEndTrigger()
    {
        StateMachine.currentState.AnimationTriggerCalled();
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
