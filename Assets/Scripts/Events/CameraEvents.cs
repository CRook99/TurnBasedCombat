using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraEvents : MonoBehaviour
{
    public static CameraEvents current;

    void Awake()
    {
        current = this;
    }
}
