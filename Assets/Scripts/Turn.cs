using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Turn
{
    public Unit Unit;

    public Turn(Unit u)
    {
        Unit = u;
    }
}
