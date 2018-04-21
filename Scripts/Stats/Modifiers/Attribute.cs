using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//TODO faire quelque chose d'intelligent avec ça
[System.Serializable]
public class ModifierAttribute {
    public int count;
    public bool inverse;
    public float duration;
    public float value;
    public int statValueType;

    public ModifierAttribute()
        :this(0, false, 0f, 0f, 0) { }

    public ModifierAttribute(int p_count, bool p_inverse, float p_duration, float p_value, int p_statValueType) {
        count = p_count;
        inverse = p_inverse;
        duration = p_duration;
        value = p_value;
        statValueType = p_statValueType;
    }
}
