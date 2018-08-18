using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UISkill : MonoBehaviour {

	public Image skillIconImage;
	public Image cooltimeBlind;
	float _cooltime;
	public float cooltime	//0 ~ 1 percent
	{
		set
		{
			_cooltime = value;
			UpdateUI();
		}
		get{return _cooltime;}
	}
	
	public Sprite skillIcon
	{
		set
		{
			skillIconImage.sprite = value;
		}
		get{return skillIconImage.sprite;}
	}

	float cooltimeBlindOrgHeight;
	float cooltimeBlindOrgScaleY;
	float cooltimeBlindMinY;
	// Update is called once per frame
	void Awake()
	{
		float cooltimeBlindHeightPerUnit = GetComponent<RectTransform>().rect.height;
		cooltimeBlindOrgHeight = cooltimeBlind.transform.lossyScale.y * cooltimeBlindHeightPerUnit;
		cooltimeBlindMinY = cooltimeBlind.transform.position.y - cooltimeBlindOrgHeight / 2;
		cooltimeBlindOrgScaleY = cooltimeBlind.transform.localScale.y;
		cooltime = 0.7f;
	}
	public void UpdateUI()
	{
		float newY = cooltimeBlindMinY + cooltimeBlindOrgHeight * cooltime / 2;
		float newScaleY = cooltimeBlindOrgScaleY * cooltime;
		cooltimeBlind.transform.position = new Vector3(cooltimeBlind.transform.position.x, newY);
		cooltimeBlind.transform.localScale = new Vector3(cooltimeBlind.transform.localScale.x, newScaleY);
	}
}
