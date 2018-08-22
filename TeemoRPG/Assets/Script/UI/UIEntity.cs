using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UIEntity : MonoBehaviour
{

    public Canvas canvas;
    public GameObject textNamePrefab;
    public GameObject textDamageIndicatorPrefab;
    public GameObject healthBarPrefab;
    public bool isEnableHealthBar;
    public bool isEnableName;
    public bool isEnableDamageIndicator;
    
    List<UIBar> healthBarList = new List<UIBar>();  //Entityid , Healthbar
    List<Text> nameList = new List<Text>();       //EntityId, name


    public void Awake()
    {

    }
    public void Update()
    {
        UpdateHealthBar();
        UpdateEntityName();
    }

    public void UpdateEntityName()
    {
        if(isEnableName)
        {
            var entities = GameManager.GetEntities();
            ObjectPool pool = ObjectPoolManager.GetObjectPool(textNamePrefab);
            int oldSize = nameList.Count;
            int newSize = 0;
            while(entities.MoveNext())
            {
                Entity entity = entities.Current;
                ++newSize;
                if(oldSize < newSize)
                {
                    ++oldSize;
                    GameObject name = pool.PopItem();
                    nameList.Add(name.GetComponent<Text>());
                    name.transform.SetParent(canvas.transform);
                }
                Sprite sprite = entity.GetComponent<SpriteRenderer>().sprite;
                nameList[newSize - 1].text = entity.name;
                nameList[newSize - 1].transform.position = entity.transform.position 
                - Vector3.up * entity.transform.localScale.y * sprite.rect.height / sprite.pixelsPerUnit / 2;
            }
            while(oldSize > newSize)
            {
                
                GameObject obj = nameList[oldSize - 1].gameObject;
                ObjectPoolManager.GetObjectPool(obj).PushItem(obj);
                nameList.RemoveAt(oldSize - 1);
                --oldSize;
            }
        }
    }
    public void UpdateHealthBar()
    {
        if(isEnableHealthBar)
        {
            var entities = GameManager.GetEntities();
            ObjectPool pool = ObjectPoolManager.GetObjectPool(healthBarPrefab);
            int oldSize = healthBarList.Count;
            int newSize = 0;
            while(entities.MoveNext())
            {
                Entity entity = entities.Current;
                ++newSize;
                if(oldSize < newSize)
                {
                    ++oldSize;
                    GameObject healthBar = pool.PopItem();
                    healthBarList.Add(healthBar.GetComponent<UIBar>());
                    healthBar.transform.SetParent(canvas.transform);
                }
                Sprite sprite = entity.GetComponent<SpriteRenderer>().sprite;
                healthBarList[newSize - 1].maxValue = entity.maxHp;
                healthBarList[newSize - 1].value = entity.hp;
                healthBarList[newSize - 1].transform.position = entity.transform.position 
                + Vector3.up * entity.transform.localScale.y * sprite.rect.height / sprite.pixelsPerUnit / 2;
            }
            while(oldSize > newSize)
            {
                GameObject obj = healthBarList[oldSize - 1].gameObject;
                ObjectPoolManager.GetObjectPool(obj).PushItem(obj);
                healthBarList.RemoveAt(oldSize - 1);
                --oldSize;
            }
        }
    }
    public void CreateDamageIndicator(Entity entity, float damage)
    {
        if(isEnableDamageIndicator)
        {
            GameObject damageIndicator = ObjectPoolManager.GetObjectPool(textDamageIndicatorPrefab).PopItem();
            DamageIndicator damageIndicatorScript = damageIndicator.GetComponent<DamageIndicator>();
            Sprite sprite = entity.GetComponent<SpriteRenderer>().sprite;
            Vector2 startPos = entity.transform.position + Vector3.up * entity.transform.localScale.y * sprite.rect.height / sprite.pixelsPerUnit / 2;
            damageIndicatorScript.Init(startPos, damage);

            damageIndicator.transform.SetParent(canvas.transform);
            
        }
    }
}