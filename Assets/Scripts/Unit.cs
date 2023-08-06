using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum UnitType {
    Ally,
    Enemy,
}

public abstract class Unit : MonoBehaviour
{
    public int ID { get; set; }

    [Header("====== Stats ======")]
    [SerializeField] protected UnitScriptableObject _stats;
    [SerializeField] Stat _attackStat;
    [SerializeField] Stat _defenceStat;
    [SerializeField] Stat _speedStat;

    // Properties for access
    public UnitScriptableObject Stats { get { return _stats; } }
    public int Attack { get { return _attackStat.Value(); } }
    public int Defence { get { return _defenceStat.Value(); } }
    public int Speed { get { return _speedStat.Value(); } }

    [Header("===== Gameplay =====")]
    public int Health;
    public List<SkillScriptableObject> Skills;
    
    [Space]

    [Header("===== Camera =====")]
    public MeshRenderer meshRenderer; // TODO: Make MeshRenderer get automatically instead of manual reference in Unity
    public GameObject Core;
    
    protected void Awake() {
        Health = _stats.MaxHealth;
        _attackStat = new Stat(_stats.Attack);
        _defenceStat = new Stat(_stats.Defence);
        _speedStat = new Stat(_stats.Speed);
    }

    void Start() 
    {
        
    }

    void Update()
    {
        
    }

    public abstract Transform GetDefaultCamTransform();

    public void ShowMesh() { meshRenderer.enabled = true; }

    public void HideMesh() { meshRenderer.enabled = false; }

    public void HealthIncrease(int amount)
    {
        Health = Mathf.Clamp(Health + amount, 0, _stats.MaxHealth);
        UIEvents.current.ValueUpdated(ID);
    }

    public void HealthDecrease(int amount)
    {
        Health = Mathf.Clamp(Health - amount, 0, _stats.MaxHealth);
        UIEvents.current.ValueUpdated(ID);
    }
}
