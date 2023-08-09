using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SkillUIElement : MonoBehaviour
{
    SkillScriptableObject _data;
    [SerializeField] Image _base;
    [SerializeField] Image _fore;
    [SerializeField] TextMeshProUGUI _nameLabel;
    [SerializeField] TextMeshProUGUI _resourceLabel;
    [SerializeField] Image _icon;


    void Initialize(SkillScriptableObject skill)
    {
        _data = skill;
        _base.color = _data.Element.SecondaryColor;
        _fore.color = _data.Element.PrimaryColor;
        _nameLabel.text = _data.Name;
        _resourceLabel.text = _data.Resource.ToString();
        _icon.sprite = _data.Element.Icon;
    }
}
