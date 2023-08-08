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

    public event Action OnTurnBegin;
    public void TurnBegin()
    {
        OnTurnBegin?.Invoke();
    }

    public event Action OnTurnEnd;
    public void TurnEnd()
    {
        OnTurnEnd?.Invoke();
    }
}
