using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "UnitScriptableObject", menuName = "Scriptable Objects/Unit")]
public class UnitScriptableObject : ScriptableObject
{
    public int MaxHealth;
    public int MaxMana;
    public int Attack;
    public int Defence;
    public int Speed;
    public List<Element> Resistance;
    public Sprite Portrait;
}
