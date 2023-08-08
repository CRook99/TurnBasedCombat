using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyUIManager : MonoBehaviour
{
    public static EnemyUIManager current;
    public GameObject EnemyUIElementPrefab;

    public Dictionary<int, Enemy> Enemies;
    public Dictionary<int, EnemyUIElement> Elements;

    void Awake()
    {
        current = this;
    }
    
    void Start()
    {
        UIEvents.current.OnEnemyValueUpdated += SendUpdateMessage;
    }

    public void Initialize(List<Enemy> enemyList)
    {
        Enemies = new Dictionary<int, Enemy>();
        Elements = new Dictionary<int, EnemyUIElement>();
        foreach (Enemy enemy in enemyList)
        {
            Enemies.Add(enemy.ID, enemy);
            EnemyUIElement element = Instantiate(EnemyUIElementPrefab, this.transform).GetComponent<EnemyUIElement>();
            Elements.Add(enemy.ID, element);
            element.Initialize(enemy);
        }
    }

    void SendUpdateMessage(int ID)
    {
        Elements[ID].UpdateSliderValues();
    }
}
