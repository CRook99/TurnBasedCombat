using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Haymaker : SkillScriptableObject
{
    public Unit Source;
    public Unit Target;

    public override void Activate()
    {
        Target.TakeDamage(Source.Attack());
    }
}
