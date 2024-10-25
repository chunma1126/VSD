using System.Collections.Generic;
using UnityEngine;

public class Pool<T> where T : Poolable
{
    private Stack<T> _pool = new Stack<T>();
    
    private T _prefab;
    private Transform _parent;
    private PoolingType _type;
    
    
    public Pool(T prefab, Transform parent, PoolingType type,int count)
    {
        _prefab = prefab;
        _parent = parent;
        _type = type;

        for (int i = 0; i < count; i++)
        {
            T obj = GameObject.Instantiate(prefab, parent);
            obj.type = type;
            obj.gameObject.name = type.ToString();
            obj.gameObject.SetActive(false);
            _pool.Push(obj);
        }
    }

    public T Pop()
    {
        T obj = null;
        
        if (_pool.Count <= 0)
        {
            obj = GameObject.Instantiate(_prefab, _parent);
            obj.type = _type;
            obj.gameObject.name = _type.ToString();
        }
        
        obj = _pool.Pop();
        obj.gameObject.SetActive(true);
        
        return obj;
    }

    public void Push(T obj)
    {
        obj.gameObject.SetActive(false);
        _pool.Push(obj);
    }
}