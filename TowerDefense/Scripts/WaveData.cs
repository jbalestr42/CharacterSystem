using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class WaveData : ScriptableObject {

    public string _name;
    public Enemy _gameObject;
    public int _count;
    public float _interval;

    [MenuItem("Assets/Create/Wave Data")]
    public static void CreateAsset() {
        ScriptableObjectUtility.CreateAsset<WaveData>();
    }
}

/*
 * Spawner difficulty
 * Interval
 * Count
 * 
 * Monster difficulty
 * Health
 * Speed
 * Special ability (speed up, resistance to stun, slow, disable towers, etc.)
 * 
 */
