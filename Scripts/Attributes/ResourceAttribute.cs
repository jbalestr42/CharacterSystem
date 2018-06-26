using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ResourceAttribute : Attribute<float> {

    public ResourceAttribute(float p_value, float p_min, float p_max)
        : base(p_value) {
        SetValue(AttributeValueType.Add, 0f);
        SetValue(AttributeValueType.Min, p_min);
        SetValue(AttributeValueType.Max, p_max);
        SetValue(AttributeValueType.Add, 0f);
    }

    public override void AfterModifierUpdate() {
        float newBase = GetValue(AttributeValueType.Base) + GetValue(AttributeValueType.Add);        
        SetValue(AttributeValueType.Base, Mathf.Clamp(newBase, GetValue(AttributeValueType.Min), GetValue(AttributeValueType.Max)));
        SetValue(AttributeValueType.Add, 0f);
    }

    public override float Value {
        get { return GetValue(AttributeValueType.Base); }
    }

    public override void SetAttributeParam(BaseAttributeParam p) {
        var att = BaseAttributeParam.Cast<AttributeParam<float>>(p);
        SetValue(att.attributeValueType, GetValue(att.attributeValueType) + att.value * att.factor);
    }
}