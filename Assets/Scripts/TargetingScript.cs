using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetingScript : MonoBehaviour
{
    public int _targetIndex;

    /*
    public void Initialize(List<Unit> enemies)
    {
        _enemies = new List<Unit>(enemies);
        _targetIndex = 0;
        _targetPos = Camera.main.WorldToScreenPoint(_enemies[_targetIndex].Core.transform.position);
        _selector.transform.position = _targetPos;
    }
    */

    void Start()
    {
        ControlEvents.current.onCursorLeft += MoveLeft;
        ControlEvents.current.onCursorRight += MoveRight;
        TurnEvents.current.onTurnBegin += CheckValidTarget;

        _targetIndex = GameState.current.ActiveEnemies.Count / 2;
    }

    void MoveLeft()
    {
        if (_targetIndex > 0) 
        {
            _targetIndex--;
            UIEvents.current.TargetChanged(TargetChangeDirection.Left);
        }
        else
        {
            // Reject
        }
    }

    void MoveRight()
    {
        if (_targetIndex < GameState.current.ActiveEnemies.Count - 1) 
        {
            _targetIndex++;
            UIEvents.current.TargetChanged(TargetChangeDirection.Right);
        }
        else 
        {
            // Reject
        }
    }

    // Bring _targetIndex back into valid bounds
    void CheckValidTarget()
    {
        if (_targetIndex >= GameState.current.ActiveEnemies.Count)
        {
            _targetIndex = GameState.current.ActiveEnemies.Count - 1;
        }
    }
}
