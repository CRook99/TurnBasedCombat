using UnityEngine;

public enum StatModifierType {
    Flat,
    Percent,
    PercentBased,
}
public class StatModifier
{
    public readonly int Value;
    public readonly StatModifierType Type;

    public StatModifier(int value, StatModifierType type, Stat basedStat = null) {
        Value = value;
        if (type == StatModifierType.PercentBased) { 
            Value = (int) Mathf.Round(value/100 * basedStat.BaseValue);
        }
        Type = type;
    }
}
