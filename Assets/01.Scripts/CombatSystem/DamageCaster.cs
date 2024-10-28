using UnityEngine;

public class DamageCaster : MonoBehaviour,IPlayerComponent
{
    private Player player;
    public float length;
    public float casterRadius;
    public float maxDistance;
    public LayerMask whatIsEnemy;

    [SerializeField] private CameraShaker cameraShaker;
    
    public bool DamageCast()
    {
        bool isHit = Physics.SphereCast(GetStartPosition() , casterRadius , transform.forward, 
            out RaycastHit hitInfo ,maxDistance,whatIsEnemy);

        if (isHit)
        {
            if (hitInfo.collider.TryGetComponent(out IDamageable health))
            {
                float testDamage = 10;
                
                /*Vector3 direction = (hitInfo.point - transform.position).normalized;
                Physics.Raycast(transform.position ,direction , out RaycastHit hitInfo2 , Mathf.Infinity, whatIsEnemy);

                Vector3 hitImpactPos = hitInfo2.point + -direction * 0.4f; */
                
                health.GetDamage(new ActionData(hitInfo.normal , hitInfo.point + new Vector3(0,0.2f,0)  , testDamage , 3));
                
                cameraShaker.ShakeCam(0.07f);
            }
        }
        
        return isHit;
    }

    private Vector3 GetStartPosition()
    {
        return transform.position + transform.forward * -length;
    }
    
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
    
        Gizmos.DrawWireSphere(GetStartPosition(), casterRadius);
        
        Vector3 endPosition = GetStartPosition() + transform.forward * maxDistance;
        
        Gizmos.DrawWireSphere(endPosition, casterRadius);
        
    }

    public void Initialize(Player _player)
    {
        player = _player;
    }
}
