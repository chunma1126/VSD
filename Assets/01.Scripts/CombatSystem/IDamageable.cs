using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public interface IDamageable
{
    public void GetDamage(ActionData actionData);
    public void Dead();
    
}
