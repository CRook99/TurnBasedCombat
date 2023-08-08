using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class CameraManager : MonoBehaviour
{
    Camera _cam;

    [Header("Position")]
    [SerializeField] Unit _currentUnit;

    void Awake() 
    {
        _cam = Camera.main;
    }

    void Start()
    {
        TurnEvents.current.OnTurnBegin += OnTurnBegin;
    }

    public void OnTurnBegin() {
        _currentUnit = TurnManager.current.CurrentUnit();
        Transform newTransform = _currentUnit.GetDefaultCamTransform();
        _cam.transform.SetPositionAndRotation(newTransform.position, newTransform.rotation);
    }
}
