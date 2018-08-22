using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ObjectPoolManager
{
    static Dictionary<string, ObjectPool> poolList = new Dictionary<string, ObjectPool>();

    public static ObjectPool FindObjectPool(GameObject obj)
    {
        ObjectPool pool;
        poolList.TryGetValue(obj.name, out pool);
        return pool;
    }
    public static ObjectPool CreateObjectPool(GameObject obj)
    {
        ObjectPool pool = new ObjectPool(obj);
        poolList.Add(obj.name, pool);
        return pool;
    }
    public static ObjectPool GetObjectPool(GameObject obj)
    {
        ObjectPool pool;
        pool = FindObjectPool(obj);
        if(pool == null)
            pool = CreateObjectPool(obj);
        return pool;
    }
}