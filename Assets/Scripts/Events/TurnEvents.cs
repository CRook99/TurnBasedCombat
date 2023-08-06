using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnEvents : MonoBehaviour
{
    public static TurnEvents current;

    void Awake() 
    {
        current = this;
    }

    public event Action onTurnBegin;
    public void TurnBegin()
    {
        onTurnBegin?.Invoke();
    }

    public event Action onTurnEnd;
    public void TurnEnd()
    {
        onTurnEnd?.Invoke();
    }
}
