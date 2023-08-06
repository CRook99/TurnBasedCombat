using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

[Serializable]
public class ID_Unit_Pair
{
    public int ID;
    public Unit Unit;
    public ID_Unit_Pair(int id, Unit unit)
    {
        ID = id;
        Unit = unit;
    }
}

[Serializable]
public class ID_Element_Pair
{
    public int ID;
    public AllyUIElement Element;
    public ID_Element_Pair(int id, AllyUIElement element)
    {
        ID = id;
        Element = element;
    }
}

[Serializable]
public class ID_Slider_Pair
{
    public int ID;
    public Slider Slider;
    public ID_Slider_Pair(int id, Slider slider)
    {
        ID = id;
        Slider = slider;
    }
}
