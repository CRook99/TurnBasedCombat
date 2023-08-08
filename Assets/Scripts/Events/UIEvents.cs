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

    public event Action<int> OnAllyValueUpdated;
    public void AllyValueUpdated(int ID)
    {
        OnAllyValueUpdated?.Invoke(ID);
    }

    public event Action<int> OnEnemyValueUpdated;
    public void EnemyValueUpdated(int ID)
    {
        OnEnemyValueUpdated?.Invoke(ID);
    }


    public event Action<TargetChangeDirection> OnTargetChanged;
    public void TargetChanged(TargetChangeDirection direction)
    {
        OnTargetChanged?.Invoke(direction);
    }
}
