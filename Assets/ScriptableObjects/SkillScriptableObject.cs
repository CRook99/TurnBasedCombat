using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum SkillType {
    Attack,
    Buff,
    Debuff,
}


public enum Resource {
    HP,
    MP,
}

[CreateAssetMenu(fileName = "SkillScriptableObject", menuName = "Scriptable Objects/Skill")]
public class SkillScriptableObject : ScriptableObject
{
    public string Name;
    [TextArea(1,3)]
    public string Description;
    public int Cost;
    public Resource Resource;
    public SkillType Type;
    public ElementScriptableObject Element;

    public virtual void Activate() {}
}