using UnityEngine;
using System.Collections;
using System;

//TODO abstract
public abstract class AStatModifier {

	[System.Serializable]
	public struct Attribute
	{
		public int count;
		public bool inverse;
		public float duration;
		public float value;
		public StatValueType statValueType;
	}

	protected Attribute _attributes;

	public void Apply(Stat p_stat, GameObject p_character) {
		float factor = GetFactor(p_character);
		p_stat.Add(_attributes.statValueType, _attributes.value * factor);
	}

	public virtual void OnEffectStart(GameObject p_owner, Attribute p_attributes) { }
	public virtual void OnEffectEnd(GameObject p_owner) { }

    public virtual bool IsOver() {
        return false;
    }

	public abstract float GetFactor(GameObject p_character);

	public static AStatModifier GetModifier(StatModifierType p_modifierType, GameObject p_owner, Attribute p_attributes) {
		AStatModifier modifierFactor = null;
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

		modifierFactor._attributes = p_attributes;
		modifierFactor.OnEffectStart(p_owner, p_attributes);

		return modifierFactor;
	}
}