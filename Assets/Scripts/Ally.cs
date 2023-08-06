using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ally : Unit
{
    [SerializeField] Transform _shoulderTransform;
    [SerializeField] Transform _focusTransform;

    public override Transform GetDefaultCamTransform()
    {
        return _shoulderTransform;
    }
}