using UnityEngine;
using UnityEngine.Assertions;

[System.Serializable]
public class BaseAttributeParam {
    public bool inverse;
    public float duration;
    public int attributeType;
    public int attributeValueType;
    public float factor;
    public ISkillCooldownTracker modifierIcon;

    public BaseAttributeParam(ISkillCooldownTracker p_modifierIcon, bool p_inverse, float p_duration, int p_attributeType, int p_attributeValueType) {
        modifierIcon = p_modifierIcon;
        inverse = p_inverse;
        duration = p_duration;
        attributeType = p_attributeType;
        attributeValueType = p_attributeValueType;
        factor = 1f;
    }
}