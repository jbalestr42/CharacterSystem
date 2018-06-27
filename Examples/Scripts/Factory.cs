using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Factory {

    public static IAttributeModifier GetModifier(AttributModifierType p_modifierType, GameObject p_owner, BaseAttributeParam p_param) {
        IAttributeModifier modifierFactor = null;
        switch (p_modifierType) {
            case AttributModifierType.Resource:
                modifierFactor = new Resource();
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

        modifierFactor.SetAttributeParam(p_param);
        modifierFactor.OnStart(p_owner);

        return modifierFactor;
    }
}
