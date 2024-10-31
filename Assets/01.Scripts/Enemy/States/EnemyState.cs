
using UnityEngine;

public class EnemyState
{
    protected Enemy Enemy;
    protected EnemyStateMachine StateMachine;
    
    protected Animator Animator;
    protected int animBoolHashName;

    protected bool isAnimationTriggerCalled;
    
    public EnemyState(Enemy enemy, EnemyStateMachine stateMachine,string animBoolName)
    {
        Enemy = enemy;
        StateMachine = stateMachine;
        animBoolHashName = Animator.StringToHash(animBoolName);

        Animator = enemy.Animator;
    }
    
    public void Enter()
    {
        Animator.SetBool(animBoolHashName,true);
        isAnimationTriggerCalled = false;
    }
    
    public void Update()
    {
        
    }
    
    public void Exit()
    {
        Animator.SetBool(animBoolHashName,false);
    }

    public void AnimationEndTriggerCalled() => isAnimationTriggerCalled = true;

}