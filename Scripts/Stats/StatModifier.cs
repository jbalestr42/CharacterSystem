using UnityEngine;
using System.Collections;
using System;

public class StatModifier {
	
	public AStatModifierFactor _modifierFactor;
    public StatValueType _statValueType;
    public float _value;

	public StatModifier(Character p_owner, float p_value, StatValueType p_valueType, StatModifierType p_modifierType, AStatModifierFactor.Attribute p_attributes) {
        _value = p_value;
        _statValueType = p_valueType;
		_modifierFactor = GetModifier(p_modifierType);
		_modifierFactor.Init(p_owner, p_attributes);
    }

	private AStatModifierFactor GetModifier(StatModifierType p_modifierType) {
		AStatModifierFactor modifierFactor = null;
		switch (p_modifierType) {
		case StatModifierType.HealthRatio:
			modifierFactor = new HealthRatio();
			break;

		case StatModifierType.DurationRatio:
			modifierFactor = new DurationRatio();
			break;

		case StatModifierType.Counter:
			modifierFactor = new Counter();
			break;

		default:
			Debug.Log("The enum " + p_modifierType.ToString() + " is not recognized.");
			return null;
		}

		return modifierFactor;
	}

	public void Apply(Stat p_stat, GameObject p_character) {
		float factor = _modifierFactor.GetFactor(p_character);
		p_stat.Add(_statValueType, _value * factor);
	}

	public void OnRemoved(GameObject p_owner) {
		if (_modifierFactor != null)
			_modifierFactor.OnRemoved(p_owner);
	}

    public bool IsOver() {
        if (_modifierFactor != null)
            return _modifierFactor.IsOver();
        return false;
    }
}