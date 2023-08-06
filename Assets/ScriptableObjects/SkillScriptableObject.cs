using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum SkillType {
    Attack,
    Buff,
    Debuff,
}

public enum Element {
    Physical,
    Fire,
    Water,
    Electric,
    Wind,
    Spirit,
    Void,
    None,
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
    public Element Element;

    public virtual void Activate() {}
}