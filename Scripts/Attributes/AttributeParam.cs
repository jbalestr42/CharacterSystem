using UnityEngine;
using UnityEngine.Assertions;

[System.Serializable]
public class AttributeParam<T> : BaseAttributeParam {
    public T value;

    public AttributeParam()
        :this(null, false, default(T), 0, 0) { }

    public AttributeParam(ISkillCooldownTracker p_modifierIcon, bool p_inverse, T p_value, int p_attributeType, int p_attributeValueType) 
        :base(p_modifierIcon, p_inverse, p_attributeType, p_attributeValueType) {
        value = p_value;
    }
}