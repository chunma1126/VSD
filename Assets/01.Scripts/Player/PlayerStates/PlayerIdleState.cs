using UnityEngine;

public class PlayerIdleState : PlayerState
{
    private Vector2 moveInput;
    
    public PlayerIdleState(Player player, PlayerStateMachine stateMachine, string animBoolName) : base(player, stateMachine, animBoolName)
    {
        
    }

    public override void Enter()
    {
        base.Enter();
    }

    public override void Update()
    {
        base.Update();

        moveInput = Player.GetMoveInput();

        if (moveInput.sqrMagnitude > 0)
        {
            StateMachine.ChangeState(PlayerStateEnum.Move);
        }
    }

    public override void Exit()
    {
        base.Exit();
    }
}