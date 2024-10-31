using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Animator Animator { get; private set; }
    
    public EnemyStateMachine StateMachine { get; private set; }
    
    private void Awake()
    {
        StateMachine = new EnemyStateMachine();

        #region AddState
        
        StateMachine.AddState(EnemyStateEnum.Recovery, new EnemyRecoveryState(this , StateMachine , "Recovery"));
        StateMachine.AddState(EnemyStateEnum.Chase, new EnemyChaseState(this , StateMachine , "Chase"));
        StateMachine.AddState(EnemyStateEnum.Attack, new EnemyAttackState(this , StateMachine , "Attack"));

        #endregion
        
        
    }

    private void Update()
    {
        StateMachine.currentEnemyState.Update();
    }
    
    
    
}
