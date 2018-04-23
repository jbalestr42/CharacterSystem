using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// TODO remove the factor to put it back in the AttributeModifier
// RenameTo BaseAttribut and make it Abstract ?

// How to put all theses variable conditionnal ? usually count dont need duration
// How to avoid having multiple subclass for each case ?
// maybe some kind of List of abstract type
[System.Serializable]
public class AttributeParam {
    public int count;
    public bool inverse;
    public float duration;
    public int attributeType;
    public int attributeValueType;
    public float factor;

    public AttributeParam()
        : this(0, false, 0f, 0, 0) { }

    public AttributeParam(int p_count, bool p_inverse, float p_duration, int p_attributeType, int p_attributeValueType) {
        count = p_count;
        inverse = p_inverse;
        duration = p_duration;
        attributeType = p_attributeType;
        attributeValueType = p_attributeValueType;
        factor = 1f;
    }
}

[System.Serializable]
public class AttributeParamT<T> : AttributeParam {
    public T value;

    public AttributeParamT()
        : this(0, false, 0f, default(T), 0, 0) { }

    public AttributeParamT(int p_count, bool p_inverse, float p_duration, T p_value, int p_attributeType, int p_attributeValueType) 
        :base(p_count, p_inverse, p_duration, p_attributeType, p_attributeValueType) {
        value = p_value;
    }
}
