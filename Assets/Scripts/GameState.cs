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
    public List<Ally> ActiveAllies;
    

    [Header("Enemies")]
    [SerializeField] GameObject _enemiesParent;
    public List<Enemy> ActiveEnemies;


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
    }

    void Initialize()
    {
        foreach (Transform child in _alliesParent.transform) {
            ActiveAllies.Add(child.GetComponent<Ally>());
            unitList.Add(child.GetComponent<Unit>());
        }

        foreach (Transform child in _enemiesParent.transform) {
            ActiveEnemies.Add(child.GetComponent<Enemy>());
            unitList.Add(child.GetComponent<Unit>());
        }

        for (int i = 0; i < unitList.Count; i++)
        {
            unitList[i].ID = i;
        }

        TurnManager.current.Initialize(ActiveAllies, ActiveEnemies);
        AllyUIManager.current.Initialize(ActiveAllies);
    }
}
