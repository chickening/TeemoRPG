using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGeneralAttack:SkillData
{
    public GameObject bulletPrefab;
    void Awake()
    {
        Init("PlayerGeneralAttack", 0.5f);
    }
    public override bool Condition(Entity user, Vector2 targetPos, Entity targetEntity = null)
    {
        return true;
    } 
    public override void Use(Entity user, Vector2 targetPos, Entity targetEntity = null)
    {
        GameObject bullet = ObjectPoolManager.GetObjectPool(bulletPrefab).PopItem();
        Bullet bulletScript = bullet.GetComponent<Bullet>();
        bulletScript.Init(user, (Vector2)targetPos - (Vector2)user.gameObject.transform.position,user.damage,10);
    }
}