using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTurntable : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        TurnEvents.current.OnTurnEnd += PointToActive;
        PointToActive();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void PointToActive()
    {
        Unit unit = TurnManager.current.CurrentUnit();
        if (unit is Ally)
        {
            Vector3 targetVector = new Vector3(unit.transform.position.x, transform.position.y, unit.transform.position.z);
            transform.LookAt(targetVector);
        }
        else
        {
            transform.rotation = Quaternion.Euler(transform.eulerAngles.x, 180, transform.eulerAngles.z);
        }
    }
}
