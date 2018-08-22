using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UIManager : MonoBehaviour {

	[SerializeField]
	private UIBar _hpBar;
	[SerializeField]
	private UIBar _mpBar;
	[SerializeField]	
	private UISkill[] _skillUI;
	[SerializeField]
	private UIEntity _entityUI;

	public UIBar hpBar{	get{return _hpBar;}}
	public UIBar mpBar{	get{return _mpBar;}}
	public UISkill GetUISkill(int index)
	{
		return _skillUI[index];
	}
	public UIEntity entityUI{get {return _entityUI;}}
	public static UIManager instance
	{
		private set; get;
	}

	void Awake()
	{
		instance = this;
	}
	
}
