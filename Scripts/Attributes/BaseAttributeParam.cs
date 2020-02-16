/// <summary>
/// The base class containing the minimum data to modify an Attribute through an AttributeModifier
/// 
/// The attributeType is Attribute to modify
/// The attributeValueType is the component of the attribute to modify
/// </summary>
[System.Serializable]
public class BaseAttributeParam {
    public int attributeType;
    public int attributeValueType;

    public BaseAttributeParam(int p_attributeType, int p_attributeValueType) {
        attributeType = p_attributeType;
        attributeValueType = p_attributeValueType;
    }
}