using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyVFX : MonoBehaviour
{
    private EnemyHealth _health;

    private void Start()
    {
        _health = GetComponentInParent<EnemyHealth>();
        _health.OnHitEvent += HandleHitImpactPlay;
    }

    private void HandleHitImpactPlay(ActionData actionData)
    {
        HitImpact newHitImpact = PoolManager.Instance.Pop(PoolingType.HitImpact) as HitImpact;;
        newHitImpact.transform.position = actionData.hitPoint;
        newHitImpact.transform.rotation = Quaternion.LookRotation(actionData.normal);
        
    }

    private void OnDestroy()
    {
        _health.OnHitEvent -= HandleHitImpactPlay;
    }
}
