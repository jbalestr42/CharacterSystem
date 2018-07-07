using UnityEngine;
using UnityEngine.Assertions;

[System.Serializable]
public class BaseAttributeParam {
    public bool inverse;
    public int attributeType;
    public int attributeValueType;
    public ISkillCooldownTracker modifierIcon;

    public BaseAttributeParam(ISkillCooldownTracker p_modifierIcon, bool p_inverse, int p_attributeType, int p_attributeValueType) {
        modifierIcon = p_modifierIcon;
        inverse = p_inverse;
        attributeType = p_attributeType;
        attributeValueType = p_attributeValueType;
    }
}