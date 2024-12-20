using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;

public class Player : MonoBehaviour
{
    private PlayerStateMachine StateMachine;
    
    public InputSO input;
    
    [Header("Attack Info")] 
    public float[] attackDamagePercent;
    public Vector2[] attackMovement;//x
    public float attackDuration;
    public int comboCounter;
    
    public bool canChangeState = true;

    #region Component
    public Animator Animator { get; private set; }
    #endregion
    
    private Dictionary<Type, IPlayerComponent> _playerComponents;
    
    private void Awake()
    {
        #region PlayerComponentInitialize
        _playerComponents = new Dictionary<Type, IPlayerComponent>();
        GetComponentsInChildren<IPlayerComponent>().ToList().ForEach(compo => _playerComponents.Add(compo.GetType(), compo));
        _playerComponents.Add(input.GetType(), input);
        
        foreach (var compo in _playerComponents.Values)
        {
            compo.Initialize(this);
        }
        #endregion
        
        #region ComponentInitialize
        Animator = GetComponentInChildren<Animator>();
        #endregion
        
        #region StateInitialize
        StateMachine = new PlayerStateMachine();
        StateMachine.AddState(PlayerStateEnum.Idle , new PlayerIdleState(this ,StateMachine ,"Idle"));
        StateMachine.AddState(PlayerStateEnum.Move , new PlayerMoveState(this ,StateMachine ,"Move"));
        StateMachine.AddState(PlayerStateEnum.Attack , new PlayerAttackState(this,StateMachine,"Attack"));
        StateMachine.AddState(PlayerStateEnum.Dodge , new PlayerDodgeState(this,StateMachine,"Dodge"));
        #endregion      
        
        input.OnAttackEvent += ()=>
        {
            if(!canChangeState)return;
            
            StateMachine.ChangeState(PlayerStateEnum.Attack);
        };
        input.OnDodgeEvent += ()=>
        {
            if(!canChangeState)return;
            
            StateMachine.ChangeState(PlayerStateEnum.Dodge);
        };
    }
    
    public T GetCompo<T>() where T : class
    {
        if(_playerComponents.TryGetValue(typeof(T), out IPlayerComponent compo))
        {
            return compo as T;
        }
        return default;
    }

    private void Start()
    {
        StateMachine.Initialize(PlayerStateEnum.Idle);
    }

    private void Update()
    {
        StateMachine.currentState.Update();
    }
    
    public Vector2 GetMoveInput()
    {
        return input.MoveInput;
    }
    
    public void AnimationEndTrigger()
    {
        StateMachine.currentState.AnimationTriggerCalled();
    }

    public void DamageCast()
    {
        GetCompo<DamageCaster>().DamageCast();
    }
    
    
    public void PlaySlashEffect()
    {
        GetCompo<PlayerVFX>().PlaySlashEffect(comboCounter);
    }

    public float GetCurrentAttackCurrent()
    {
        return attackDamagePercent[comboCounter];
    }
    
    public Coroutine StartDelayCallback(float time, Action Callback)
    {
        return StartCoroutine(DelayCoroutine(time, Callback));
    }
   
    private IEnumerator DelayCoroutine(float time, Action Callback)
    {
        yield return new WaitForSeconds(time);
        Callback?.Invoke();
    }
}
