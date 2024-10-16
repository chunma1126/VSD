using UnityEngine;

public class PlayerAttackState : PlayerState
{
    private PlayerMovement _movement;
    
    private float lastAttackTime;
    private int comboCounter;
    private float attackDuration;
    private int maxComboCount = 2;

    private int comboCountHash;
    
    public PlayerAttackState(Player player, PlayerStateMachine stateMachine, string animBoolName) : base(player, stateMachine, animBoolName)
    {
        _movement = player.Movement;
        attackDuration = player.attackDuration;
        comboCountHash = Animator.StringToHash("ComboCount");
    }

    public override void Enter()
    {
        base.Enter();
        
        _movement.StopImmediately();
        
        
        Player.input.OnAttackEvent -= Player.EnterAttackState;
        
        bool comoboCounterOver = comboCounter > maxComboCount;
        bool comboWindowExhaust = Time.time >= lastAttackTime + attackDuration;

        if (comoboCounterOver || comboWindowExhaust)
            comboCounter = 0;
        
        Animator.SetInteger(comboCountHash , comboCounter);
        
        
        _movement.SetMovement(Player.transform.forward * Player.attackMovement[comboCounter].y);
        Player.StartDelayCallback(Player.attackMovement[comboCounter].x, () =>
        {
           _movement.StopImmediately();
        });

        
    }

    public override void Update()
    {
        base.Update();
        if (isAnimationTrigger)
        {
            StateMachine.ChangeState(PlayerStateEnum.Idle);
        }
        
    }

    public override void Exit()
    {
        base.Exit(); 
        comboCounter++;
        Player.input.OnAttackEvent += Player.EnterAttackState;
        
        lastAttackTime = Time.time;
    }
}