using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Unit
{
    [SerializeField] Transform _focusTransform;
    [SerializeField] Transform _UIAnchor;
    public Transform UIAnchor { get { return _UIAnchor; } }

    public override Transform GetDefaultCamTransform()
    {
        return _focusTransform;
    }

    public override void HealthIncrease(int amount)
    {
        Health = Mathf.Clamp(Health + amount, 0, _stats.MaxHealth);
        UIEvents.current.EnemyValueUpdated(ID);
    }

    public override void HealthDecrease(int amount)
    {
        Health = Mathf.Clamp(Health - amount, 0, _stats.MaxHealth);
        UIEvents.current.EnemyValueUpdated(ID);
    }
}