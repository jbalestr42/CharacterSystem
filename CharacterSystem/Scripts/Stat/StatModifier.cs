using UnityEngine;
using System.Collections;
using System;

public class StatModifier {
	
	public AStatModifierFactor m_modifierFactor;
    public StatValueType m_statValueType;
    public float m_value;

	public StatModifier(Character p_owner, float p_value, StatValueType p_valueType, StatModifierType p_modifierType, AStatModifierFactor.Attribute p_attributes) {
        m_value = p_value;
        m_statValueType = p_valueType;
		m_modifierFactor = GetModifier(p_modifierType);
		m_modifierFactor.Init(p_owner, p_attributes);
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

		case StatModifierType.DamageCounter:
			modifierFactor = new DamageCounter();
			break;

		default:
			Debug.Log("The enum " + p_modifierType.ToString() + " is not recognized.");
			return null;
		}

		return modifierFactor;
	}

	public void Apply(Stat p_stat, GameObject p_character) {
		float factor = m_modifierFactor.GetFactor(p_character);
		p_stat.add(m_statValueType, m_value * factor);
    }

    public bool IsOver() {
        if (m_modifierFactor != null)
            return m_modifierFactor.IsOver();
        return false;
    }
}