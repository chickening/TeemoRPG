using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrogGeneralAttack:SkillData
{
    public GameObject bulletPrefab;
    void Awake()
    {
        Init("FrogGeneralAttack", 1f);
    }
    public override bool Condition(Entity user, Vector2 targetPos, Entity targetEntity = null)
    {
        return true;
    } 
    public override void Use(Entity user, Vector2 targetPos, Entity targetEntity = null)
    {
        GameObject bullet = ObjectPoolManager.GetObjectPool(bulletPrefab).PopItem();
        Bullet bulletScript = bullet.GetComponent<Bullet>();
        bulletScript.Init(user, (Vector2)targetPos - (Vector2)user.gameObject.transform.position,user.damage,3);
    }
}