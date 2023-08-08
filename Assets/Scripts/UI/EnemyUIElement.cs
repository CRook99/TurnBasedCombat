using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyUIElement : MonoBehaviour
{
    [SerializeField] Slider _HPSlider;
    List<Image> _barList;
    Enemy _enemy;
    Camera _cam;

    void Start()
    {
        _cam = Camera.main;
        _HPSlider = GetComponent<Slider>();

        _barList = new List<Image>();
        GetComponentsInChildren(_barList);

        TurnEvents.current.OnTurnBegin += OnTurnBegin;
        OnTurnBegin();
    }

    public void Initialize(Enemy enemy)
    {
        _enemy = enemy;
        _HPSlider.value = _HPSlider.maxValue = enemy.Stats.MaxHealth;
    }

    
    void Update()
    {
        transform.position = _cam.WorldToScreenPoint(_enemy.UIAnchor.position);
    }

    public void UpdateSliderValues()
    {
        _HPSlider.value = _enemy.Health;
    }

    void OnTurnBegin()
    {
        Unit currentUnit = TurnManager.current.CurrentUnit();
        if (currentUnit is Ally || currentUnit.ID == _enemy.ID) Show();
        else Hide();
    }

    void Show()
    {
        foreach (Image image in _barList) image.enabled = true;
    }

    void Hide()
    {
        foreach (Image image in _barList) image.enabled = false;
    }
}
