using UnityEngine;

public class PlayerMoveState : PlayerState
{
    private PlayerMovement _movement;
    private Vector2 moveInput;
    
    private PlayerStatManager StatManager;
    
    public PlayerMoveState(Player player, PlayerStateMachine stateMachine, string animBoolName) : base(player, stateMachine, animBoolName)
    {
        _movement = Player.GetCompo<PlayerMovement>();
        StatManager = player.GetCompo<PlayerStatManager>();
    }

    public override void Enter()
    {
        base.Enter();
    }

    public override void Update()
    {
        base.Update();
        moveInput = Player.GetMoveInput();

        if (moveInput.sqrMagnitude <= 0)
        {
            StateMachine.ChangeState(PlayerStateEnum.Idle);
        }

        float speed = StatManager.GetStat(Stat.MoveSpeed);
        _movement.SetMovement(new Vector3(moveInput.x * speed, 0 , moveInput.y * speed),true);
                
        LookAtMoveDirection();
    }

    public override void Exit()
    {
        base.Exit();
    }
    
    private void LookAtMoveDirection()
    {
        Vector3 direction = (new Vector3(moveInput.x, 0, moveInput.y).normalized);
        direction.y = 0;
        
        Quaternion lookTarget = Quaternion.LookRotation(direction);
        Player.transform.rotation = Quaternion.Slerp(Player.transform.rotation, lookTarget, Time.deltaTime * 10);
    }
}