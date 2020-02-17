[System.Serializable]
public class AttributeParam<T> : BaseAttributeParam
{
    public T value;

    public AttributeParam()
        : this(default(T), 0, 0) { }

    public AttributeParam(T p_value, int p_attributeType, int p_attributeValueType)
        : base(p_attributeType, p_attributeValueType)
    {
        value = p_value;
    }
}