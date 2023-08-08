using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlEvents : MonoBehaviour
{
    public static ControlEvents current;

    void Awake() 
    {
        current = this;
    }

    public event Action OnCursorLeft;
    public void CursorLeft()
    {
        OnCursorLeft?.Invoke();
    }

    public event Action OnCursorRight;
    public void CursorRight()
    {
        OnCursorRight?.Invoke();
    }
}
