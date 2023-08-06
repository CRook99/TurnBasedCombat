using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AllyUIManager : MonoBehaviour
{
    public static AllyUIManager current;
    public RectTransform TeamPanel;
    public RectTransform TeamPanelBase;
    public GameObject UnitElementPrefab;
    
    public Dictionary<int, Ally> Allies;
    public Dictionary<int, AllyUIElement> Elements;

    void Awake()
    {
        current = this;
    }

    void Start()
    {
        UIEvents.current.onValueUpdated += SendUpdateMessage;
    }

    public void Initialize(List<Ally> alliesList)
    {
        Allies = new Dictionary<int, Ally>();
        Elements = new Dictionary<int, AllyUIElement>();
        //Allies = new List<ID_Unit_Pair>();
        //Elements = new List<ID_Element_Pair>();
        foreach (Ally ally in alliesList)
        {
            Allies.Add(ally.ID, ally);
            AllyUIElement currentElement = Instantiate(UnitElementPrefab, TeamPanelBase).GetComponent<AllyUIElement>();
            Elements.Add(ally.ID, currentElement);
            currentElement.Initialize(ally);
        }
        TeamPanel.sizeDelta = new Vector2((330 * Allies.Count), TeamPanel.sizeDelta.y);
    }

    void SendUpdateMessage(int ID)
    {
        Elements[ID].UpdateSliderValues();
    }
}
