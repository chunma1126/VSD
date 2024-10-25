using UnityEngine;

[CreateAssetMenu(menuName = "SO/Pool/Item")]
public class PoolItemSO : ScriptableObject
{
    public string PoolingName;
    [TextArea] public string description;
    public int poolCount;
    public Poolable prefab;
}