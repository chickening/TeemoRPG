using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillReader
{
    SkillData skillData;
    public Delay delay{get; private set;}
    public SkillReader(SkillData _skillData)
    {
        skillData = _skillData; 
        delay = new Delay(0);
    }
    public void Use(Entity user, Vector2 targetPos, Entity targetEntity)
    {
        if(delay.Check() && skillData.Condition(user , targetPos, targetEntity))
        {
            skillData.Use(user, targetPos, targetEntity);
            delay.Start(skillData.coolTime);
        }
    }
}