using System.Collections.Generic;

public enum EnemyStateEnum
{
    Recovery,
    Chase,
    Attack
}

public class EnemyStateMachine
{
    public EnemyState currentEnemyState;
    public Dictionary<EnemyStateEnum, EnemyState> States = new();
    
    
    private void Initialize(EnemyStateEnum enemyStateEnum)
    {
        currentEnemyState = States[enemyStateEnum];
        currentEnemyState.Enter();
    }

    public void AddState(EnemyStateEnum stateEnum , EnemyState state)
    {
        States.Add(stateEnum , state);
    }
    
    public void ChangeState(EnemyStateEnum enemyStateEnum)
    {
        currentEnemyState.Exit();
        currentEnemyState = States[enemyStateEnum];
        currentEnemyState.Enter();
    }
    
    public void Update()
    {
        currentEnemyState.Update();
    }
    
}