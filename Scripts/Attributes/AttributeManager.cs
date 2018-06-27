using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/*
 * Contains all the attributes, provide helper methods to add and remove modifiers
 * */
public class AttributeManager : MonoBehaviour {
	
	public Dictionary<int, AAttribute> _attributes = new Dictionary<int, AAttribute>();

	void Update() {
        foreach (var attribute in _attributes) {
            attribute.Value.Update(gameObject);
        }
	}

	public void AddAttribute(int p_attributeType, AAttribute p_stat) {
		_attributes.Add(p_attributeType, p_stat);
        p_stat.Update(gameObject);
    }

    public Attribute<T> GetAttribute<T>(int p_type) {
        var attribute = AAttribute.Cast<Attribute<T>>(_attributes[p_type]);
        if (attribute != null) {
            return attribute;
        }
        return null;
    }

    public void SetAttributeParam(BaseAttributeParam p_attributes) {
        _attributes[p_attributes.attributeType].SetAttributeParam(p_attributes);
    }

    public void AddModifier(IAttributeModifier p_attributeModifier) {
        if (_attributes.ContainsKey(p_attributeModifier.GetAttributeType())) {
            _attributes[p_attributeModifier.GetAttributeType()].AddModifier(p_attributeModifier);
        }
    }

    public void RemoveModifier(IAttributeModifier p_stateModifier) {
        if (_attributes.ContainsKey(p_stateModifier.GetAttributeType())) {
            _attributes[p_stateModifier.GetAttributeType()].RemoveModifier(p_stateModifier);
        }
    }
}
