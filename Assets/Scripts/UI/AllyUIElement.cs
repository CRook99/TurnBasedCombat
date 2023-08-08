using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AllyUIElement : MonoBehaviour
{
    [SerializeField] Image Portrait;
    [SerializeField] Slider HPSlider;
    [SerializeField] Slider MPSlider;
    //[SerializeField] UnitScriptableObject Data;
    Ally _ally;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void Initialize(Ally ally)
    {
        _ally = ally;
        Portrait.sprite = ally.Stats.Portrait;
        HPSlider.value = HPSlider.maxValue = ally.Stats.MaxHealth;
        MPSlider.value = MPSlider.maxValue = ally.Stats.MaxMana;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateSliderValues()
    {
        HPSlider.value = _ally.Health;
        MPSlider.value = _ally.Mana;
    }
}
