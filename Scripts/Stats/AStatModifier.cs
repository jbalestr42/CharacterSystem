using UnityEngine;
using System.Collections;
using System;

public abstract class AStatModifier {

    ModifierAttribute _attributes;

    public void Apply(AAttribute p_stat, GameObject p_character) {
        float factor = GetFactor(p_character);
        p_stat.Add(_attributes.statValueType, _attributes.value * factor);
    }

    public virtual void OnStart(GameObject p_owner) { }
    public virtual void OnEnd(GameObject p_owner) { }

    public virtual bool IsOver() {
        return false;
    }

    public abstract float GetFactor(GameObject p_character);

    protected ModifierAttribute Attribute {
        get { return _attributes; }
    }

    // Utiliser une generic factory
	public static AStatModifier GetModifier(StatModifierType p_modifierType, GameObject p_owner, ModifierAttribute p_attributes) {
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

            case StatModifierType.Duration:
                modifierFactor = new Duration();
                break;
            default:
			Debug.Log("The enum " + p_modifierType.ToString() + " is not recognized.");
			return null;
		}

		modifierFactor._attributes = p_attributes;
		modifierFactor.OnStart(p_owner);

		return modifierFactor;
	}
}