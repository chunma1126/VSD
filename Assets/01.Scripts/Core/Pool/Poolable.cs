using UnityEngine;

public abstract class Poolable : MonoBehaviour
{
    public PoolingType type;
    public abstract void ResetItem();

}