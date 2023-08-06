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

    public void ManaIncrease(int amount)
    {
        Mana = Mathf.Clamp(Mana + amount, 0, _stats.MaxMana);
        UIEvents.current.ValueUpdated(ID);
    }

    public void ManaDecrease(int amount)
    {
        Mana = Mathf.Clamp(Mana + amount, 0, _stats.MaxMana);
        UIEvents.current.ValueUpdated(ID);
    }

    public override Transform GetDefaultCamTransform()
    {
        return _shoulderTransform;
    }
}