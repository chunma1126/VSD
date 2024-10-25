using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "SO/Pool/List")]
public class PoolItemListSO : ScriptableObject
{
    public List<PoolItemSO> poolItemList;
    public List<PoolItemSO> GetList() => poolItemList;

  


}