using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Entity : MonoBehaviour {


	protected List<SkillReader> skillReaderList = new List<SkillReader>();
	protected Rigidbody2D entityRigidbody;
	public float maxHp;
	public float hp;
	public float maxMp;
	public float mp;
	public float level;
	public float damage;
	public float speed;
	public int faction;

	bool isFirst = true;
	
	protected virtual void Start ()
	{
		entityRigidbody = GetComponent<Rigidbody2D>();
	}

	protected virtual void OnEnable () 
	{
		GameManager.AddEntity(this);
		ResetEntity();
	}
	// Update is called once per frame
	protected virtual void Update ()
	{
		
	}


	public void UseSkill(int index, Vector2 targetPos,Entity targetEntity)
	{
		skillReaderList[index].Use(this, targetPos, targetEntity);
	}
	public SkillReader GetSkillReader(int index)
	{
		return skillReaderList[index];
	}
	public virtual void Die()
	{
		GameManager.RemoveEntity(this);
		ObjectPoolManager.GetObjectPool(gameObject).PushItem(gameObject);
	}
	public virtual void GetDamage(Entity sender, float damage)
	{
		hp -= damage; 
		UIManager.instance.entityUI.CreateDamageIndicator(this,damage);
		hp = Mathf.Clamp(hp,0,maxHp);

		if(hp == 0)
			Die();
	}
	public void ResetEntity()
	{
		hp = maxHp;
		mp = maxMp;
	}
	public List<Entity> FindEnemyInRadius(float radius)	//나중에 옮기기 
	{
		Collider2D[] colliders;
		List<Entity> enemyList = new List<Entity>();
		colliders = Physics2D.OverlapCircleAll(transform.position, radius);

		int size = colliders.Length;
		for(int i = 0; i < size; i++)
		{
			Entity otherEntity = colliders[i].transform.GetComponent<Entity>();
			if(otherEntity == null)
				continue;
			if(otherEntity.faction != faction)
				enemyList.Add(otherEntity);
		}
		return enemyList;
	}
}
