using UnityEngine;
using System.Collections;
using System;

public class AttributeModifier {

    BaseAttributeParam _params;

    public virtual void OnStart(GameObject p_owner) { }
    public virtual void Update(GameObject p_owner) {
        Param.factor = GetFactor();
        if (Param.inverse) {
            Param.factor = 1f - Param.factor;
        }
        p_owner.GetComponent<AttributeManager>().SetAttributeParam(Param);
    }
    public virtual void OnEnd(GameObject p_owner) { }
    public virtual bool IsOver() { return false; }
    public virtual float GetFactor() { return 1f; }

    public BaseAttributeParam Param {
        get { return _params; }
    }

    // Utiliser une generic factory
	public static AttributeModifier GetModifier(AttributModifierType p_modifierType, GameObject p_owner, BaseAttributeParam p_param) {
		AttributeModifier modifierFactor = null;
		switch (p_modifierType) {
		    case AttributModifierType.Regen:
			    modifierFactor = new Regen();
			    break;

            case AttributModifierType.DurationRatio:
                modifierFactor = new DurationRatio();
                break;


            case AttributModifierType.Duration:
                modifierFactor = new Duration();
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