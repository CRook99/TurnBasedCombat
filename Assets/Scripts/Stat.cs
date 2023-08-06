using System.Collections.Generic;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

public enum StatType {
    Attack,
    Defence,
}

[System.Serializable]
public class Stat
{
    public int BaseValue;
    [SerializeField] int _value;
    [SerializeField] bool isDirty;
    

    private readonly List<StatModifier> flatModifiers;
    private readonly List<StatModifier> percentModifiers;
    private readonly List<StatModifier> percentBasedModifiers;

    public Stat() : this(-1) {}

    public Stat(int bv) {
        BaseValue = bv;
        _value = BaseValue;
        flatModifiers = new List<StatModifier>();
        percentModifiers = new List<StatModifier>();
        percentBasedModifiers = new List<StatModifier>();
        isDirty = false;
    }

    public int Value() {
        if (isDirty) {
            _value = CalculateFinalValue();
        }

        return _value;
    }

    public void AddMod(StatModifier mod) {
        isDirty = true;
        switch (mod.Type) {
            case StatModifierType.Flat:
                flatModifiers.Add(mod);
                break;
            case StatModifierType.Percent:
                percentModifiers.Add(mod);
                break;
            case StatModifierType.PercentBased:
                percentBasedModifiers.Add(mod);
                break;
            default:
                Debug.LogWarning("Unknown StatModifierType on add");
                break;
        }
    }

    public void RemoveMod(StatModifier mod) {
        isDirty = true;
        switch (mod.Type) {
            case StatModifierType.Flat:
                flatModifiers.Remove(mod);
                break;
            case StatModifierType.Percent:
                percentModifiers.Remove(mod);
                break;
            case StatModifierType.PercentBased:
                percentBasedModifiers.Remove(mod);
                break;
            default:
                Debug.LogWarning("Unknown StatModifierType on remove");
                break;
        }
    }

    public void RemoveAllMods() {
        isDirty = true;
        flatModifiers.Clear();
        percentModifiers.Clear();
        percentBasedModifiers.Clear();
    }

    int CalculateFinalValue() {
        float finalValue = BaseValue;

        foreach (StatModifier mod in flatModifiers) {
            finalValue += mod.Value;
        }

        foreach (StatModifier mod in percentModifiers) {
            finalValue *= 1 + mod.Value/100;
        }

        foreach (StatModifier mod in percentBasedModifiers) {
            finalValue += mod.Value;
        }
        
        isDirty = false;
        return (int) Mathf.Round(finalValue);
    } 

}

