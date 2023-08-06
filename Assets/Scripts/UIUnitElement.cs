using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIUnitElement : MonoBehaviour
{
    //public Sprite Portrait;
    public Slider HPSlider;
    public Slider MPSlider;
    public UnitScriptableObject Data;

    // Start is called before the first frame update
    void Start()
    {
        //Portrait = transform.GetChild(0).GetComponent<Image>().sprite;
    }

    public void Initialize(Unit unit)
    {
        Data = unit.Stats;
        //Portrait = unit.Stats.Portrait; // This next
        transform.GetChild(0).GetComponent<Image>().sprite = Data.Portrait;
        HPSlider.maxValue = Data.MaxHealth;
        HPSlider.value = HPSlider.maxValue;
        MPSlider.maxValue = Data.MaxMana;
        MPSlider.value = MPSlider.maxValue;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
