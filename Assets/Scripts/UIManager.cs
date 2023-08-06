using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager current;
    public RectTransform TeamPanel;
    public RectTransform TeamPanelBase;
    public GameObject UnitElementPrefab;
    
    public Dictionary<int, Ally> Allies;
    public Dictionary<int, UIUnitElement> Elements;
    
    /*
    public List<ID_Unit_Pair> Allies;
    public List<ID_Element_Pair> Elements;
    public List<ID_Slider_Pair> HPBars;
    public List<ID_Slider_Pair> MPBars;
    */

    void Awake()
    {
        current = this;
        //UIEvents.current.onDamageTaken += ReduceHealth;
    }
    // Start is called before the first frame update
    public void Initialize(List<Ally> alliesList)
    {
        Allies = new Dictionary<int, Ally>();
        Elements = new Dictionary<int, UIUnitElement>();
        //Allies = new List<ID_Unit_Pair>();
        //Elements = new List<ID_Element_Pair>();
        foreach (Ally ally in alliesList)
        {
            Allies.Add(ally.ID, ally);
            UIUnitElement currentElement = Instantiate(UnitElementPrefab, TeamPanelBase).GetComponent<UIUnitElement>(); // This next
            Elements.Add(ally.ID, currentElement);
            currentElement.Initialize(ally);
            //Elements[ally.ID].Portrait = ally.Stats.Portrait;
        }
        TeamPanel.sizeDelta = new Vector2((330 * Allies.Count), TeamPanel.sizeDelta.y);
    }

    public void ReduceHealth(int ID, int dmg)
    {

    }


}
