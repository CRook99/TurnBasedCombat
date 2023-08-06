using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectorUIScript : MonoBehaviour
{
    [Header("References")]
    [SerializeField] SelectorScript SelectorScript;

    [Header("Graphics")]
    [SerializeField] Image _outer;
    [SerializeField] Image _inner;
    private RectTransform _rect;

    [Header("Scaling")]
    [SerializeField] AnimationCurve _scaleCurve;
    private float _currentScale;
    private float _time;

    private Vector3 _targetPos;

    void Start()
    {
        UIEvents.current.onTargetChanged += ChangeTarget;
        //UIEvents.current.onTargetChanged += ZoomSelector;
        TurnEvents.current.onTurnBegin += OnTurnBegin;

        _currentScale = _scaleCurve.Evaluate(0);
        _rect = GetComponent<RectTransform>();
        //SelectorScript = GetComponent<SelectorScript>();

        //ChangeTarget();
        //ZoomSelector();
    }


    void Update()
    {
        _outer.transform.Rotate(0, 0, 45 * Time.deltaTime);
        _inner.transform.Rotate(0, 0, -45 * Time.deltaTime);

        _time += Time.deltaTime;
        _currentScale = _scaleCurve.Evaluate(_time);
        UpdateScale(_currentScale);

        MoveSelector(); // Track target
    }


    void OnTurnBegin()
    {
        if (TurnManager.current.CurrentUnit() is Ally)
        {
            _outer.enabled = _inner.enabled = true;
            //ChangeTarget();
            ZoomSelector();
        }
        else
        {
            _outer.enabled = _inner.enabled = false;
        }
    }


    void ChangeTarget(TargetChangeDirection direction)
    {
        ZoomSelector();
    }


    void MoveSelector()
    {
        _targetPos = Camera.main.WorldToScreenPoint(GameState.current.ActiveEnemies[SelectorScript._targetIndex].Core.transform.position);
        
        transform.position = _targetPos;
    }


    void ZoomSelector()
    {
        _time = 0f;
    }


    void UpdateScale(float scale)
    {
        _rect.localScale = new Vector3(scale, scale, 1f);
    }
}
