using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class AttributeParam {
    public int count;
    public bool inverse;
    public float duration;
    public float value;
    public bool valueBool;
    public int attributeType;
    public int attributeValueType;

    public AttributeParam()
        :this(0, false, 0f, 0f, false, 0, 0) { }

    public AttributeParam(int p_count, bool p_inverse, float p_duration, float p_value, bool p_valueBool, int p_attributeType, int p_attributeValueType) {
        count = p_count;
        inverse = p_inverse;
        duration = p_duration;
        value = p_value;
        valueBool = p_valueBool;
        attributeType = p_attributeType;
        attributeValueType = p_attributeValueType;
    }
}
