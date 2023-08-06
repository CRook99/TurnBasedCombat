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

    public event Action onCursorLeft;
    public void CursorLeft()
    {
        onCursorLeft?.Invoke();
    }

    public event Action onCursorRight;
    public void CursorRight()
    {
        onCursorRight?.Invoke();
    }
}
