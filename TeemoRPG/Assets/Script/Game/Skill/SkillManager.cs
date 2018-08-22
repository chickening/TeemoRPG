using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class SkillManager
{
    static Dictionary<string, SkillData> skillList = new Dictionary<string, SkillData>();
    
    public static void AddSkill(SkillData skillData)
    {
        Debug.Log(skillData.skillName);
        skillList.Add(skillData.skillName, skillData);
    }
    public static SkillData FindSkill(string skillName)
    {
        SkillData skillData;
        skillList.TryGetValue(skillName, out skillData);
        return skillData;
    }
}