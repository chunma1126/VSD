using System;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    public Animator Animator { get; private set; }
    
    public EnemyStateMachine StateMachine { get; private set; }
    public EnemyMovement Movement { get; private set; }


    public Transform target;
        
    private void Awake()
    {
        StateMachine = new EnemyStateMachine();
        Movement = GetComponent<EnemyMovement>();
        
        #region AddState
        
        StateMachine.AddState(EnemyStateEnum.Recovery, new EnemyRecoveryState(this , StateMachine , "Recovery"));
        StateMachine.AddState(EnemyStateEnum.Chase, new EnemyChaseState(this , StateMachine , "Chase"));
        StateMachine.AddState(EnemyStateEnum.Attack, new EnemyAttackState(this , StateMachine , "Attack"));
        
        #endregion
                
        
    }

    private void Start()
    {
        StateMachine.Initialize(EnemyStateEnum.Recovery);
        Movement.Initialize(this);
        
        
        
    }
    
    private void Update()
    {
        StateMachine.currentEnemyState.Update();
    }
}
