using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool
{
    List<GameObject> pool = new List<GameObject>();
    GameObject prefab;
    public int size
    {
        get{return pool.Count;}
    }
    public int capacity{get;set;}

    public ObjectPool(GameObject _prefab, int _capacity = 10)
    {
        prefab = _prefab;
        capacity = _capacity;
    }
    public GameObject CreateItem()
    {
        GameObject obj = Object.Instantiate(prefab);
        obj.name = prefab.name;
        return obj;
    }
    public void PushItem(GameObject obj)
    {
        obj.SetActive(false);
        if(size >= capacity)
            Object.Destroy(obj);
        else
            pool.Add(obj);
    }
    public GameObject PopItem()
    {
        GameObject obj;
        if(size == 0)
        {
            obj = CreateItem();
        }
        else
        {
            obj = pool[0];
            pool.RemoveAt(0);
            obj.SetActive(true);
        }
        return obj;
    }
}