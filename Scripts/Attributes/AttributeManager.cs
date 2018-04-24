﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AttributeManager : MonoBehaviour {
	
	public Dictionary<int, AAttribute> _attributes = new Dictionary<int, AAttribute>();

	void Update() {
        foreach (var attribute in _attributes) {
            attribute.Value.Update(gameObject);
        }
        //Debug.Log(GetAttribute<float>(AttributeType.Speed).GetValue(AttributeValueType.RelativeBonus).ToString("F4"));
	}

	public void AddAttribute(int p_attributeType, AAttribute p_stat) {
		_attributes.Add(p_attributeType, p_stat);
    }

    public Attribute<T> GetAttribute<T>(int p_type) {
        // TODO assert
        var attribute = _attributes[p_type] as Attribute<T>;
        if (attribute != null) {
            return attribute;
        }
        return null;
    }

    public void SetAttributeParam(BaseAttributeParam p_attributes) {
        _attributes[p_attributes.attributeType].SetAttributeParam(p_attributes);
    }

    public void AddModifier(AttributeModifier p_attributeModifier) {
        if (_attributes.ContainsKey(p_attributeModifier.Param.attributeType)) {
            _attributes[p_attributeModifier.Param.attributeType].AddModifier(p_attributeModifier);
        }
    }

    public void RemoveModifier(AttributeModifier p_stateModifier) {
        if (_attributes.ContainsKey(p_stateModifier.Param.attributeType)) {
            _attributes[p_stateModifier.Param.attributeType].RemoveModifier(p_stateModifier);
        }
    }
}
