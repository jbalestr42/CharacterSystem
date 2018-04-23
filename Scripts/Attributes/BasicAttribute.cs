using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BasicAttribute : Attribute<float> {

    float _total = 0f;

    public BasicAttribute(float p_value, float p_min, float p_max)
        :base(p_value, p_value) {
        SetValue(AttributeValueType.AbsoluteBonus, 0f);
        SetValue(AttributeValueType.RelativeBonus, 0f);
        SetValue(AttributeValueType.Min, p_min);
        SetValue(AttributeValueType.Max, p_max);
    }

    public override void AfterModifierUpdate() {
        _total = GetValue(AttributeValueType.Base) * (1f + GetValue(AttributeValueType.RelativeBonus)) + GetValue(AttributeValueType.AbsoluteBonus);
        _total = Mathf.Clamp(_total, GetValue(AttributeValueType.Min), GetValue(AttributeValueType.Max));
        SetValue(AttributeValueType.AbsoluteBonus, 0f);
        SetValue(AttributeValueType.RelativeBonus, 0f);
    }

    public override float Value {
        get { return _total;  }
    }

    public override void SetAttributeParam(AttributeParam p) {
        // TODO asseert 
        var att = (AttributeParamT<float>)p;
        SetValue(att.attributeValueType, GetValue(att.attributeValueType) + att.value * att.factor);
    }
}