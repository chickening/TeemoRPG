using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameManager
{    
    public static Entity player{get;set;}
    static Dictionary<int, Entity> entityList = new Dictionary<int, Entity>();

    public static void AddEntity(Entity entity)
    {
        Debug.Log(entity.GetInstanceID());
        entityList.Add(entity.GetInstanceID(), entity);
    }
    public static void RemoveEntity(Entity entity)
    {
        entityList.Remove(entity.GetInstanceID());
    }
    public static IEnumerator<Entity> GetEntities()
    {
        return entityList.Values.GetEnumerator();
    }
}