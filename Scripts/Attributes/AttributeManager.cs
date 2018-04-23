using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AttributeManager : MonoBehaviour {
	
	public Dictionary<int, ABaseAttribute> _attributes = new Dictionary<int, ABaseAttribute>();

	void Update() {
        foreach (var attribute in _attributes) {
            attribute.Value.Update(gameObject);
        }
	}

	void OnGUI() {
		GUI.Label(new Rect(10, 10, 500, 20), "Attributes : ");
		int i = 2;
		foreach (var attribute in _attributes) {
			string s = attribute.Key.ToString() + " : " + attribute.Value.ToString();
			GUI.Label(new Rect(10, 15 * i++, 500, 20), s);
		}
	}

	public void AddAttribute(int p_attributeType, ABaseAttribute p_stat) {
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

    public void SetAttributeParam(AttributeParam p_attributes) {
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
