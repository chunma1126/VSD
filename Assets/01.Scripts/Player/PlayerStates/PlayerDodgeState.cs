using UnityEngine;

public class PlayerDodgeState : PlayerState
{
    private PlayerMovement Movement;
    private PlayerStatManager StatManager;
    Vector3 dodgeDir ;
    
    public PlayerDodgeState(Player player, PlayerStateMachine stateMachine, string animBoolName) : base(player, stateMachine, animBoolName)
    {
        Movement = Player.GetCompo<PlayerMovement>();
        StatManager = player.GetCompo<PlayerStatManager>();
    }

    public override void Enter()
    {
        base.Enter();
        Player.canChangeState = false;
        
        dodgeDir = Player.transform.forward;
        Movement.SetMovement(dodgeDir * StatManager.GetStat(Stat.DodgeSpeed));
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
