using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AttributeManager : MonoBehaviour {
	
	public Dictionary<int, ABaseAttribute> _stats = new Dictionary<int, ABaseAttribute>();

	void Update() {
        foreach (var stat in _stats) {
            stat.Value.Update(gameObject);
        }
	}

	void OnGUI() {
		GUI.Label(new Rect(10, 10, 500, 20), "Attributes : ");
		int i = 2;
		foreach (var stat in _stats) {
			string s = stat.Key.ToString() + " : " + stat.Value.ToString();
			GUI.Label(new Rect(10, 15 * i++, 500, 20), s);
		}
	}

	public void AddAttribute(int p_statType, ABaseAttribute p_stat) {
		_stats.Add(p_statType, p_stat);
    }

    public Attribute<T> GetAttribute<T>(int p_type) {
        // TODO assert
        var attribute = _stats[p_type] as Attribute<T>;
        if (attribute != null) {
            return attribute;
        }
        return null;
    }

    public void SetAttribute(AttributeParam p_attributes) {
        _stats[p_attributes.attributeType].Test(p_attributes);
    }

    public void AddModifier(int p_statType, AttributeModifier p_stateModifier) {
        if (_stats.ContainsKey(p_statType)) {
            _stats[p_statType].AddModifier(p_stateModifier);
        }
    }

    public void RemoveModifier(int p_statType, AttributeModifier p_stateModifier) {
        if (_stats.ContainsKey(p_statType)) {
            _stats[p_statType].RemoveModifier(p_stateModifier);
        }
    }
}
