using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    private PlayerStateMachine StateMachine;
    
    [SerializeField] public InputSO input;
        
    public float moveSpeed;

    [Header("Attack Info")] 
    public LayerMask whatIsEnemy;
    public Vector3[] attackMovement;
    public float attackDuration;
    public bool isAttack;
    
    
    public Animator Animator { get; private set; }
    public CharacterController CharacterController { get; private set; }

    private void Awake()
    {
        Animator = GetComponentInChildren<Animator>();
        CharacterController = GetComponent<CharacterController>();
        
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

    private void EnterAttackState()
    {
        if (isAttack == false)
        {
            StateMachine.ChangeState(PlayerStateEnum.Attack);
        }
    }

    public void AnimationEndTrigger()
    {
        StateMachine.currentState.AnimationTriggerCalled();
    }
    
    
    /*private void LookAtMouse()
    {
        Vector3 mousePosition = input.GetMouseWorldPosition();
        Vector3 direction = (mousePosition - transform.position).normalized;  
        
        Quaternion lookTarget = Quaternion.LookRotation(direction);
        transform.rotation = Quaternion.Slerp(transform.rotation, lookTarget, Time.deltaTime * 10);
    }*/
    
}
