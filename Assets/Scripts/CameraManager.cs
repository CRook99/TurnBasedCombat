using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class CameraManager : MonoBehaviour
{
    public static CameraManager current;
    Camera _cam;

    [Header("Position")]
    [SerializeField] Unit _currentUnit;

    void Awake() 
    {
        current = this;
        _cam = GetComponentInChildren<Camera>();
    }

    void Start()
    {
        TurnEvents.current.onTurnBegin += OnTurnBegin;
    }

    void Update()
    {

    }

    void OnTurnBegin() {
        _currentUnit = TurnManager.current.CurrentUnit();
        Transform newTransform = _currentUnit.DefaultCam.transform;
        _cam.transform.SetPositionAndRotation(newTransform.position, newTransform.rotation);

    }
}
