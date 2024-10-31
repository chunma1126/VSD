using UnityEngine;

public class PlayerAttackState : PlayerState
{
    private PlayerMovement _movement;
    
    private float lastAttackTime;
    private float attackDuration;
    private int maxComboCount = 2;

    private int comboCountHash;
    
    
    public PlayerAttackState(Player player, PlayerStateMachine stateMachine, string animBoolName) : base(player, stateMachine, animBoolName)
    {
        _movement = player.GetCompo<PlayerMovement>();
        attackDuration = player.attackDuration;
        comboCountHash = Animator.StringToHash("ComboCount");
    }

    public override void Enter()
    {
        base.Enter();

        Player.canChangeState = false;
        
        _movement.StopImmediately();
        
        bool comoboCounterOver = Player.comboCounter > maxComboCount;
        bool comboWindowExhaust = Time.time >= lastAttackTime + attackDuration;

        if (comoboCounterOver || comboWindowExhaust)
            Player.comboCounter = 0;
        
        Animator.SetInteger(comboCountHash , Player.comboCounter);
        
        _movement.SetMovement(Player.transform.forward * Player.attackMovement[Player.comboCounter].y);
        Player.StartDelayCallback(Player.attackMovement[Player.comboCounter].x, () =>
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
        Player.canChangeState = true;
        
        Player.comboCounter++;
        
        lastAttackTime = Time.time;
    }
}