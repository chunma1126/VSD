using System;
using UnityEngine;

public class EnemyHealth : MonoBehaviour , IDamageable,IEnemyComponent
{
    private Enemy Enemy;
    
    public float health;
    
    public event Action<ActionData> OnHitEvent;
    public event Action OnDeadEvent;

    private ActionData ActionData;
    
    public void Initialize(Enemy enemy)
    {
        Enemy = enemy;
    }
    
    public void GetDamage(ActionData actionData)
    {
        //test
        health -= actionData.damageAmount;
        
        OnHitEvent?.Invoke(actionData);
                
        if (health <= 0)
        {
            Dead();
        }
    }

    public void Dead()
    {
        OnDeadEvent?.Invoke();
    }

   
}