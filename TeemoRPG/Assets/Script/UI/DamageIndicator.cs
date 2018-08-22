using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class DamageIndicator : MonoBehaviour
{  
    Text text;
    Delay delay;
    public float delayTime;
    public float speedY;
    public Color colorDamageIndicatorHealed;
    public Color colorDamageIndicatorDamaged;
    public void OnEnable()
    {
        if(text == null)
            text = GetComponent<Text>();
        if(delay == null)
            delay = new Delay(delayTime);
    }
    public void Update()
    {
        if(delay.Check())
            ObjectPoolManager.GetObjectPool(gameObject).PushItem(gameObject);
        else
            gameObject.transform.position += Vector3.up * speedY;
    }
    public void Init(Vector2 pos, float damage)
    {

        gameObject.transform.position = pos;

        text.text = ((int)Mathf.Abs(damage)).ToString();
        if(damage >= 0)
            text.color = colorDamageIndicatorDamaged;
        else
            text.color = colorDamageIndicatorHealed;

        delay.Start(delayTime);
    }
}