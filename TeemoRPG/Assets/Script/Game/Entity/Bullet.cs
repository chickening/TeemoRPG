using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(BoxCollider2D))]
public class Bullet : MonoBehaviour
{
    Rigidbody2D bulletRigidbody;
    float _angle;
    public float angle
    {
        get
        {
            return _angle;
        }
        set
        {
            _angle = value;
            _direction = new Vector2(Mathf.Cos(value), Mathf.Sin(value));
            transform.rotation = Quaternion.Euler(0,0,value);
        }
    }
    Vector2 _direction;
    public Vector2 direction
    {
        get
        {
            return _direction;
        }
        set
        {
            value.Normalize();
            _angle = Mathf.Atan2(value.y, value.x) * Mathf.Rad2Deg;
            _direction = value;
            transform.rotation = Quaternion.Euler(0,0,_angle);
        }
    }
    public float speed{get;set;}
    public float damage{get;set;}
    public Entity launchar{get;private set;}
    public void Init(Entity _launcher, Vector2 _direction,float _damage, float _speed)
    {
        gameObject.transform.position = _launcher.transform.position;
        launchar = _launcher;
        direction = _direction;
        damage = _damage;
        speed =  _speed;
    }
    void OnEnable()
    {
        if(bulletRigidbody == null)
        {
            bulletRigidbody = GetComponent<Rigidbody2D>();
        }
        
    }
    void Update()
    {
        bulletRigidbody.MovePosition(bulletRigidbody.position + direction * speed * Time.fixedDeltaTime);
    }
    void OnTriggerEnter2D(Collider2D other)
    {
         if(other.gameObject.layer == LayerMask.NameToLayer("Entity"))
        {
            Entity entity = other.gameObject.GetComponent<Entity>();
            if(entity.faction != launchar.faction)
            {
                entity.GetDamage(null, damage);
                ReturnObject();
            }
        }
        else
            ReturnObject();
    }
    void ReturnObject()
    {
        ObjectPoolManager.GetObjectPool(gameObject).PushItem(gameObject);
    }
    


    
}