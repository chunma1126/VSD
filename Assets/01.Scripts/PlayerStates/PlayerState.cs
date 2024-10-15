using UnityEngine;

public class PlayerState
{
    protected Player Player;
    protected PlayerStateMachine StateMachine;

    protected int animHash;
    protected Animator Animator;

    protected bool isAnimationTrigger;
    
    public PlayerState(Player player, PlayerStateMachine stateMachine,string animBoolName)
    {
        Player = player;
        StateMachine = stateMachine;
        animHash = Animator.StringToHash(animBoolName);

        Animator = player.Animator;
    }
    
    public virtual void Enter()
    {
        Animator.SetBool(animHash , true);
        isAnimationTrigger = false;
    }

    public virtual void Update()
    {
        
    }

    public virtual void Exit()
    {
        Animator.SetBool(animHash , false);
    }

    public void AnimationTriggerCalled()
    {
        isAnimationTrigger = true;
    }
    

}