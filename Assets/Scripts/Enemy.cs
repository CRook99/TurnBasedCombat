using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Unit
{
    [SerializeField] Transform _focusTransform;

    public override Transform GetDefaultCamTransform()
    {
        return _focusTransform;
    }
}