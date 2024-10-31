using UnityEngine;

public class EnemyVFX : MonoBehaviour,IEnemyComponent
{
    private EnemyHealth _health;
    private Enemy Enemy;
    
    
    public void Initialize(Enemy enemy)
    {
        Enemy = enemy;
    }
    
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
