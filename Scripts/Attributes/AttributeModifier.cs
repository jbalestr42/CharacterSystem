using UnityEngine;
using System.Collections;
using System;

public abstract class AttributeModifier {

    AttributeParam _params;

    public virtual void OnStart(GameObject p_owner) { }
    public virtual void Update(GameObject p_character) { }
    public virtual void OnEnd(GameObject p_owner) { }
    public virtual bool IsOver() { return false; }

    public AttributeParam Param {
        get { return _params; }
    }

    // Utiliser une generic factory
	public static AttributeModifier GetModifier(AttributModifierType p_modifierType, GameObject p_owner, AttributeParam p_param) {
		AttributeModifier modifierFactor = null;
		switch (p_modifierType) {
		    case AttributModifierType.HealthRatio:
			    modifierFactor = new HealthRatio();
			    break;

            case AttributModifierType.DurationRatio:
                modifierFactor = new DurationRatio();
                break;


            case AttributModifierType.Duration:
                modifierFactor = new Duration();
                break;

            case AttributModifierType.Counter:
			    modifierFactor = new Counter();
			    break;

            default:
			Debug.Log("The enum " + p_modifierType.ToString() + " is not recognized.");
			return null;
		}

		modifierFactor._params = p_param;
		modifierFactor.OnStart(p_owner);

		return modifierFactor;
	}
}