using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AttributeManager))]
public class Tower : MonoBehaviour {

    void Awake() {
        // Init all attribute from data
        AttributeManager attributeManager = GetComponent<AttributeManager>();
        attributeManager.AddAttribute(AttributeType.Damage, new BasicAttribute(80, 0, 1000));
        attributeManager.AddAttribute(AttributeType.AttackRate, new BasicAttribute(1, 0, 10));
        attributeManager.AddAttribute(AttributeType.Range, new BasicAttribute(80, 0, 1000));
    }

    /*
     * User can choose a target
     * Focus the first
     * Focus the faster
     * User can change the setting for each tower
     */
    public GameObject GetTarget() {
        var enemies = FindObjectOfType<GameManager>().Enemies;
        Attribute<float> range = GetComponent<AttributeManager>().GetAttribute<float>(AttributeType.Range);
        foreach (var enemy in enemies) {
            if (Vector3.Distance(transform.position, enemy.transform.position) < range.Value) {
                return enemy.gameObject;
            }
        }
        return null;
    }
}
