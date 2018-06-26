// How to put all theses variable conditionnal ? usually count dont need duration
// How to avoid having multiple subclass for each case ?
// maybe some kind of List of abstract type
using UnityEngine;
using UnityEngine.Assertions;

[System.Serializable]
public class BaseAttributeParam {
    public int count;
    public bool inverse;
    public float duration;
    public int attributeType;
    public int attributeValueType;
    public float factor;
    public ModifierIcon modifierIcon;

    public BaseAttributeParam()
        :this(null, 0, false, 0f, 0, 0) { }

    public BaseAttributeParam(ModifierIcon p_modifierIcon, int p_count, bool p_inverse, float p_duration, int p_attributeType, int p_attributeValueType) {
        modifierIcon = p_modifierIcon;
        count = p_count;
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

[System.Serializable]
public class AttributeParam<T> : BaseAttributeParam {
    public T value;

    public AttributeParam()
        :this(null, 0, false, 0f, default(T), 0, 0) { }

    public AttributeParam(ModifierIcon p_modifierIcon, int p_count, bool p_inverse, float p_duration, T p_value, int p_attributeType, int p_attributeValueType) 
        :base(p_modifierIcon, p_count, p_inverse, p_duration, p_attributeType, p_attributeValueType) {
        value = p_value;
    }
}

[System.Serializable]
public class ResourceAttributeParam : AttributeParam<float> {
    public int regenAttributeType;
    public int maxAttributeType;

    public ResourceAttributeParam()
        :this(null, 0, 0, 0) { }

    public ResourceAttributeParam(ModifierIcon p_modifierIcon, int p_regenAttributeType, int p_maxAttributeType, int p_attributeType) 
        :base(p_modifierIcon, 0, false, 0f, 0f, p_attributeType, 0) {
        regenAttributeType = p_regenAttributeType;
        maxAttributeType = p_maxAttributeType;
    }
}
