using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameState : MonoBehaviour
{
    public static GameState current;
    public List<Unit> unitList;

    [Header("Allies")]
    [SerializeField] GameObject _alliesParent;
    public List<Unit> ActiveAllies;
    

    [Header("Enemies")]
    [SerializeField] GameObject _enemiesParent;
    public List<Unit> ActiveEnemies;


    void Awake()
    {
        current = this;
    }

    void Start()
    {
        Initialize();
    }

    void Update() 
    {
        if (Input.GetKeyDown("t")) {
            TurnManager.current.EndTurn();
        }

        // Buff test
        if (Input.GetKeyDown("b")) {
            TurnManager.current.CurrentUnit().AttackStat.AddMod(new StatModifier(25, StatModifierType.Flat));
            Debug.Log(TurnManager.current.CurrentUnit().AttackStat.Value());
        }
    }

    void Initialize()
    {
        foreach (Transform child in _alliesParent.transform) {
            ActiveAllies.Add(child.GetComponent<Unit>());
            unitList.Add(child.GetComponent<Unit>());
        }

        foreach (Transform child in _enemiesParent.transform) {
            ActiveEnemies.Add(child.GetComponent<Unit>());
            unitList.Add(child.GetComponent<Unit>());
        }

        for (int i = 0; i < unitList.Count; i++)
        {
            unitList[i].ID = i;
        }

        TurnManager.current.Initialize(ActiveAllies, ActiveEnemies);
        UIManager.current.Initialize(ActiveAllies);
    }
}
