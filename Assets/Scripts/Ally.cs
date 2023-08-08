using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ally : Unit
{
    [SerializeField] Transform _shoulderTransform;
    [SerializeField] Transform _focusTransform;

    [Space]
    public int Mana;

    new void Awake()
    {
        base.Awake();
        Mana = _stats.MaxMana;
    }

    public override void HealthIncrease(int amount)
    {
        Health = Mathf.Clamp(Health + amount, 0, _stats.MaxHealth);
        UIEvents.current.AllyValueUpdated(ID);
    }

    public override void HealthDecrease(int amount)
    {
        Health = Mathf.Clamp(Health - amount, 0, _stats.MaxHealth);
        UIEvents.current.AllyValueUpdated(ID);
    }

    public void ManaIncrease(int amount)
    {
        Mana = Mathf.Clamp(Mana + amount, 0, _stats.MaxMana);
        UIEvents.current.AllyValueUpdated(ID);
    }

    public void ManaDecrease(int amount)
    {
        Mana = Mathf.Clamp(Mana + amount, 0, _stats.MaxMana);
        UIEvents.current.AllyValueUpdated(ID);
    }

    public override Transform GetDefaultCamTransform()
    {
        return _shoulderTransform;
    }
}