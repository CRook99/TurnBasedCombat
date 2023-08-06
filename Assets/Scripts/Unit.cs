using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum UnitType {
    Ally,
    Enemy,
}

public class Unit : MonoBehaviour
{
    [Header("====== Stats ======")]
    public Stat AttackStat;
    public Stat DefenceStat;
    public Stat SpeedStat;
    public UnitScriptableObject Stats;
    [Space]

    [Header("===== Camera =====")]
    public GameObject DefaultCam;
    public GameObject CameraTurntable;
    //public GameObject CamFocus;
    public MeshRenderer meshRenderer; // TODO: Make MeshRenderer get automatically instead of manual reference in Unity

    public GameObject Core;


    [Header("===== Gameplay =====")]
    public int Health;
    public int Mana;
    public UnitType Type;
    public List<SkillScriptableObject> Skills;
    public int ID;
    



    void Awake() {
        // Initialize gametime stats
        Health = Stats.MaxHealth;
        Mana = Stats.MaxMana;
        AttackStat = new Stat(Stats.Attack);
        DefenceStat = new Stat(Stats.Defence);
        SpeedStat = new Stat(Stats.Speed);
    }

    void Start() 
    {
        
    }

    

    // TODO Implement enemy target mesh show
    public void SetMesh(Unit u)
    {
        if (Type == UnitType.Enemy) return; // Enemy visibility not affected by turn

        meshRenderer.enabled = ID == u.ID;
    }

    public void ShowMesh() { meshRenderer.enabled = true; }

    public void HideMesh() { meshRenderer.enabled = false; }

    public void UseSkill()
    {

    }

    public void TakeDamage(int dmg) 
    {
        Health -= dmg;
        //UIEvents.current.DamageTaken(ID, dmg);
    }

    public void ReceiveHeal(int heal)
    {
        Health += heal;
    }



    public int Attack() { return AttackStat.Value(); }
    public int Defence() { return DefenceStat.Value(); }
    public int Speed() { return SpeedStat.Value(); }
   
}
