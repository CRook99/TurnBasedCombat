using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum TargetChangeDirection
    {
        Left,
        Right,
    }

public class UIEvents : MonoBehaviour
{
    public static UIEvents current;

    

    void Awake()
    {
        current = this;
    }

    public event Action<int, int> onDamageTaken;
    public void DamageTaken(int ID, int dmg)
    {
        if (onDamageTaken != null) onDamageTaken(ID, dmg);
    }

    public event Action<int> onHealReceived;
    public void HealReceived(int heal)
    {
        if (onHealReceived != null) onHealReceived(heal);
    }

    public event Action<TargetChangeDirection> onTargetChanged;
    public void TargetChanged(TargetChangeDirection direction)
    {
        if (onTargetChanged != null) onTargetChanged(direction);
    }
}
