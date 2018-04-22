using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Duration : AttributeModifier {

    protected float _endOfEffect;

    public override void OnStart(GameObject p_owner) {
        _endOfEffect = Time.realtimeSinceStartup + Attributes.duration;
    }

    public override void Update(GameObject p_owner) {
        Attribute<float> attributeFloat = p_owner.GetComponent<AttributeManager>().GetAttribute<float>(Attributes.attributeType);
        if (attributeFloat != null) {
            attributeFloat.SetValue(Attributes.attributeValueType, attributeFloat.GetValue(Attributes.attributeValueType) + Attributes.value);
        }
        Attribute<bool> attributeBool = p_owner.GetComponent<AttributeManager>().GetAttribute<bool>(Attributes.attributeType);
        if (attributeBool != null) {
            attributeBool.SetValue(Attributes.attributeValueType, Attributes.valueBool);
        }
    }

    public override bool IsOver() {
        return (_endOfEffect - Time.realtimeSinceStartup) <= 0.0f;
    }

    public float GetRatio() {
        return Mathf.Clamp((_endOfEffect - Time.realtimeSinceStartup) / Attributes.duration, 0.0f, 1.0f);
    }
}