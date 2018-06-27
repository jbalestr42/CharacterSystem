// How to put all theses variable conditionnal ? usually count dont need duration
// How to avoid having multiple subclass for each case ?
// maybe some kind of List of abstract type
using UnityEngine;
using UnityEngine.Assertions;

[System.Serializable]
public class BaseAttributeParam {
    public bool inverse;
    public float duration;
    public int attributeType;
    public int attributeValueType;
    public float factor;
    public ISkillCooldownUpdater modifierIcon;

    public BaseAttributeParam(ISkillCooldownUpdater p_modifierIcon, bool p_inverse, float p_duration, int p_attributeType, int p_attributeValueType) {
        modifierIcon = p_modifierIcon;
        inverse = p_inverse;
        duration = p_duration;
        attributeType = p_attributeType;
        attributeValueType = p_attributeValueType;
        factor = 1f;
    }

    public static T Cast<T>(BaseAttributeParam p_value) where T : BaseAttributeParam {
        T value = (T)p_value;
        Assert.IsNotNull(value);
        return value;
    }
}