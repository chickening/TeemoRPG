using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class SkillData : MonoBehaviour
{
    public string skillName{get;private set;}
    public float coolTime{get;private set;}
    public float consumeMp{get; private set;}
    [SerializeField]
    private Sprite _skillIcon;                                                                                                                                                                                                                                                                                                                                  
    public Sprite skillIcon{get{return _skillIcon;}}

    public void Init(string _skillName, float _coolTime)
    {
        skillName = _skillName;
        coolTime = _coolTime;
        SkillManager.AddSkill(this);
    }
    public virtual bool Condition(Entity user, Vector2 targetPos, Entity targetEntity = null)
    {
        return false;
    }
    public virtual void Use(Entity user, Vector2 targetPos, Entity targetEntity = null)
    {
        
    }
}