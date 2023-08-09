using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum ElementName {
    Physical,
    Fire,
    Water,
    Electric,
    Wind,
    Spirit,
    Void,
    None,
}

[CreateAssetMenu(fileName = "ElementScriptableObject", menuName = "Scriptable Objects/Element")]
public class ElementScriptableObject : ScriptableObject
{
    [SerializeField] ElementName _name;
    [SerializeField] Color _primaryColor;
    [SerializeField] Color _secondaryColor;
    [SerializeField] Sprite _icon;

    public ElementName Name { get { return _name; } }
    public Color PrimaryColor { get { return _primaryColor; } }
    public Color SecondaryColor { get { return _secondaryColor; } }
    public Sprite Icon { get { return _icon; } }
}
