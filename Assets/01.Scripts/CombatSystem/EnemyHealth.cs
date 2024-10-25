using System;
using UnityEngine;

public class EnemyHealth : MonoBehaviour , IDamageable
{
    public float health;
    
    public event Action<ActionData> OnHitEvent;
    public event Action OnDeadEvent;

    private ActionData ActionData;
    
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