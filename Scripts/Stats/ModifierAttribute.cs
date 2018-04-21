using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Attribute {
    public int count;
    public bool inverse;
    public float duration;
    public float value;
    public int statValueType;

    public Attribute()
        : this(0, false, 0f, 0f, 0) { }

    public Attribute(int p_count, bool p_inverse, float p_duration, float p_value, int p_statValueType) {
        count = p_count;
        inverse = p_inverse;
        duration = p_duration;
        value = p_value;
        statValueType = p_statValueType;
    }
}
