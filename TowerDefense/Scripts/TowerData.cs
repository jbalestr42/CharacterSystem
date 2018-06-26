using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class TowerData : ScriptableObject {

    public TextAsset _shape;
    public GameObject _gameObject;
    public float _cost;

    [HideInInspector]
    public Vector2Int Size = Vector2Int.zero;

    [HideInInspector]
    public int[,] Shape;

    public void Init() {
        var lines = _shape.text.Split('\n');
        Size.x = int.Parse(lines[0].Split('x')[0]);
        Size.y = int.Parse(lines[0].Split('x')[1]);
        Shape = new int[Size.x, Size.y];

        for (int i = 1; i < lines.Length; i++) {
            var line = lines[i].Split(' ');
            for (int j = 0; j < line.Length; j++) {
                Shape[i - 1, j] = int.Parse(line[j]);
            }
        }
    }

    [MenuItem("Assets/Create/Tower Data")]
    public static void CreateAsset() {
        ScriptableObjectUtility.CreateAsset<TowerData>();
    }
}
