using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PoolingType
{
    HitImpact,
    
    None,
    
}

public class PoolManager : Monosinleton<PoolManager>
{
    private Dictionary<PoolingType, Pool<Poolable>> _pools = new();

    public PoolItemListSO ListSo;
    
    private void Awake()
    {
        foreach (var item in ListSo.GetList())
        {
            CreatePool(item);
        }
        
        
    }

    private void CreatePool(PoolItemSO item)
    {
        PoolingType poolingType = PoolingType.None;
        
        foreach (PoolingType enumName in Enum.GetValues(typeof(PoolingType)))
        {
            if (item.PoolingName == enumName.ToString())
            {
                item.prefab.type = enumName;
                poolingType = enumName;
            }
        }
        
        Pool<Poolable> pool = new Pool<Poolable>(item.prefab , transform , poolingType , item.poolCount);
        _pools.Add(poolingType , pool);
        
    }

    public Poolable Pop(PoolingType type)
    {
        if (_pools.ContainsKey(type) == false)
        {
            Debug.LogError("No PoolingType");
            return null;
        }

        Poolable poolable = _pools[type].Pop();
        poolable.ResetItem();

        return poolable;
    }

    public void Push(Poolable poolable)
    {
        _pools[poolable.type].Push(poolable);
    }
}
