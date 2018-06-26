using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AttributeManager))]
public class GameManager : MonoBehaviour {

    public List<WaveData> _waves;
    public List<Spawner> _spawners;

    public GameObject _moneyText;
    public UnityEngine.UI.Button _buttonStart;

    int _difficulty = 0;
    List<Enemy> _enemies;

    void Awake() {
        AttributeManager attributeManager = GetComponent<AttributeManager>();
        attributeManager.AddAttribute(AttributeType.Money, new ResourceAttribute(100, 0, 1000));
        UpdateMoney(0f);
        _enemies = new List<Enemy>();
    }

    public bool EnoughMoney(float p_amount) {
        return GetComponent<AttributeManager>().GetAttribute<float>(AttributeType.Money).Value >= p_amount;
    }

    public void UpdateMoney(float p_amount) {
        GetComponent<AttributeManager>().GetAttribute<float>(AttributeType.Money).SetValue(AttributeValueType.Add, p_amount);
        GetComponent<AttributeManager>().GetAttribute<float>(AttributeType.Money).Update(gameObject);
        _moneyText.GetComponent<UnityEngine.UI.Text>().text = "Money: " + GetComponent<AttributeManager>().GetAttribute<float>(AttributeType.Money).Value;
    }

    public WaveData GetWaveData() {
        return _waves[Mathf.Clamp(_difficulty, 0, _waves.Count)];
    }

    public Enemy GetNewEnemy(Enemy p_enemyPrefab) {
        Enemy enemy = Instantiate(p_enemyPrefab);
        _enemies.Add(enemy);
        return enemy;
    }

    public void DestroyEnemy(Enemy p_enemy) {
        _enemies.Remove(p_enemy);
        Destroy(p_enemy.gameObject);
    }

    public void StartLevel() {
        foreach (var spawner in _spawners) {
            spawner.StartSpawn(GetWaveData());
        }
        _buttonStart.interactable = false;
    }

    public void EndLevel() {
        foreach (var spawner in _spawners) {
            if (!spawner.IsOver) {
                return;
            }
        }
        _difficulty++;
        Debug.Log("Level end : " + _difficulty);
        _buttonStart.interactable = true;
    }

    public List<Enemy> Enemies { get { return _enemies; } }
}
