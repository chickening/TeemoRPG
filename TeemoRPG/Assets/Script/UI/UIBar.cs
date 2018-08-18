using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIBar : MonoBehaviour {

	// Use this for initialization
	public Text textNum;
	public GameObject gauge;
	float gaugeMinX;
	float gaugeOrgWidth;
	float gaugeOrgScaleX;
	float _maxValue = 100;
	public float maxValue
	{
		set
		{
			_maxValue = value;
			UpdateBar();
		}
		get{return _maxValue;}
	}

	float _value = 100;
	public float value
	{
		set	
		{	
			_value = Mathf.Clamp(value,0,maxValue);
			UpdateBar();
		}
		get{return _value;}
	}

	void Awake()
	{
		RectTransform gaugeRectTransfrom = gauge.GetComponent<RectTransform>();
		float gaugeWidthPerUnit= gaugeRectTransfrom.rect.width;
		gaugeOrgWidth = gauge.transform.lossyScale.x * gaugeWidthPerUnit;
		gaugeMinX = gauge.transform.position.x - gaugeOrgWidth / 2;
		gaugeOrgScaleX = gauge.transform.localScale.x;
		maxValue = 100;
		value = 30;
	}
	void UpdateBar()
	{
		float percent = value / maxValue;

		float newGaugeX = gaugeMinX + percent * gaugeOrgWidth / 2;
		float newScaleX = gaugeOrgScaleX * percent;
		gauge.transform.position = new Vector3(newGaugeX ,gauge.transform.position.y);
		gauge.transform.localScale = new Vector3(newScaleX, gauge.transform.localScale.y);

		textNum.text = value.ToString() + " / " + maxValue;
	}
}
