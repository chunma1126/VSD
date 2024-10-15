using System.Collections.Generic;
using UnityEngine.Assertions.Must;

public enum PlayerStateEnum
{
    Idle,
    Move,
    Dodge,
    Attack
}

public class PlayerStateMachine
{
    private Dictionary<PlayerStateEnum, PlayerState> _playerStates = new Dictionary<PlayerStateEnum, PlayerState>();
    public PlayerState currentState;
    
    public void AddState(PlayerStateEnum stateEnum, PlayerState playerState)
    {
        _playerStates.Add(stateEnum , playerState);
    }
    
    public void ChangeState(PlayerStateEnum playerStateEnum)
    {
        currentState.Exit();
        currentState = _playerStates[playerStateEnum];
        currentState.Enter();
    }

    public void Initialize(PlayerStateEnum playerStateEnum)
    {
        currentState = _playerStates[playerStateEnum];
        currentState.Enter();
    }

}