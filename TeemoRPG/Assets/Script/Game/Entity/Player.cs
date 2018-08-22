using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Entity {

	public float exp;
	public float[] levelUpNeededExp;//level]

	protected override void Start()
	{
		base.Start();
		skillReaderList.Add(new SkillReader(SkillManager.FindSkill("PlayerGeneralAttack")));	//1
		skillReaderList.Add(new SkillReader(SkillManager.FindSkill("PlayerGeneralAttack")));	//2
		skillReaderList.Add(new SkillReader(SkillManager.FindSkill("PlayerGeneralAttack")));	//3
		skillReaderList.Add(new SkillReader(SkillManager.FindSkill("PlayerGeneralAttack")));	//4
		skillReaderList.Add(new SkillReader(SkillManager.FindSkill("PlayerGeneralAttack")));	//LM
		skillReaderList.Add(new SkillReader(SkillManager.FindSkill("PlayerGeneralAttack")));	//RM
	}
	
}
