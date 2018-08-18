using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UIManager : MonoBehaviour {

	public UIBar _hpBar;
	public UIBar _mpBar;
	public UISkill[] _skillUI;

	public UIBar hpBar{	get{return _hpBar;}}
	public UIBar mpBar{	get{return _mpBar;}}
	public UISkill GetUISkill(int index)
	{
		return _skillUI[index];
	}
	public static UIManager instnace
	{
		private set; get;
	}

	void Awake()
	{
		instnace = this;
	}
	
}
