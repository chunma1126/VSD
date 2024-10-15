using UnityEngine;

public class PlayerAttackState : PlayerState
{
    private float lastAttackTime;
    private int comboCounter;
    private float attackDuration;
    private int maxComboCount = 1;

    private int comboCountHash;
    
    public PlayerAttackState(Player player, PlayerStateMachine stateMachine, string animBoolName) : base(player, stateMachine, animBoolName)
    {
        attackDuration = player.attackDuration;
        comboCountHash = Animator.StringToHash("ComboCount");
    }

    public override void Enter()
    {
        base.Enter();
        Player.isAttack = true;
        
        if (lastAttackTime + attackDuration > Time.time || comboCounter >= (maxComboCount - 1))
        {
            comboCounter = 0;
        }
        else
        {
            comboCounter++;
        }
        Animator.SetInteger(comboCountHash , comboCounter);


        Player.CharacterController.Move(Player.attackMovement[comboCounter] * Time.deltaTime);
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
        lastAttackTime = Time.time;
        Player.isAttack = false;
    }
}