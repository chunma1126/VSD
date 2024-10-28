using UnityEngine;

public class PlayerDodgeState : PlayerState
{
    private PlayerMovement Movement;
    Vector3 dodgeDir ;
    
    public PlayerDodgeState(Player player, PlayerStateMachine stateMachine, string animBoolName) : base(player, stateMachine, animBoolName)
    {
        Movement = Player.Movement;
    }

    public override void Enter()
    {
        base.Enter();
        Player.canChangeState = false;
        
        dodgeDir = Player.transform.forward;
        Movement.SetMovement(dodgeDir * Player.dodgeSpeed);
    }

    public override void Update()
    {
        base.Update();
        
        
        if (isAnimationTrigger)
        {
            StateMachine.ChangeState(PlayerStateEnum.Idle);
            Movement.StopImmediately();
        }
        
    }

    public override void Exit()
    {
        base.Exit();
        Player.canChangeState = true;
    }
}
