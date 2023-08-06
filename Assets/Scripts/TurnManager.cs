using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class TurnManager : MonoBehaviour
{
    public static TurnManager current;
    public List<Unit> turns;

    void Awake()
    {
        current = this;
    }

    public void Initialize(List<Ally> allies, List<Enemy> enemies) {
        turns = new List<Unit>(allies).Concat(enemies).ToList(); // Put all units in turn list
        turns.Sort((x, y) => y.Speed.CompareTo(x.Speed)); // Reversed x,y = descending

        BeginTurn();
    }

    public Unit CurrentUnit() {
        return turns[0];
    }

    public void BeginTurn() {
        TurnEvents.current.TurnBegin();
    }

    public void EndTurn() {
        Unit temp = turns[0];
        turns.RemoveAt(0);
        turns.Add(temp);
        TurnEvents.current.TurnEnd();

        BeginTurn();
    }
}
