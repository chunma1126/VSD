using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour,IEnemyComponent
{
    private Enemy Enemy;

    public NavMeshAgent Agent { get; private set; }
    public Rigidbody Rigidbody { get; private set; }

    
    private Vector3 destination;
    
    public void Initialize(Enemy enemy)
    {
        Enemy = enemy;
        Agent = GetComponent<NavMeshAgent>();
        Rigidbody = GetComponent<Rigidbody>();
    }

    public void SetMovement(Vector3 newDestination)
    {
        destination = newDestination;
        Agent.isStopped = false;
        
        Agent.SetDestination(destination);
    }
    
    public void StopImmediately()
    {
        Agent.isStopped = true;
    }
}