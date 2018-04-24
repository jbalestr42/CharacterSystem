using System.Collections.Generic;

public class Attribute<T> : AAttribute {

    Dictionary<int, T> _values;
    T _value;

    public Attribute()
        :this(default(T), default(T)) { }

    public Attribute(T p_value, T p_defaultValue) {
        _values = new Dictionary<int, T>();
        SetValue(AttributeValueType.Base, p_value);
        SetValue(AttributeValueType.Default, p_defaultValue);
    }

    public T GetValue(int p_type) {
        return _values[p_type];
    }

    public void SetValue(int p_type, T p_value) {
        _values[p_type] = p_value;
    }

    public override void AfterModifierUpdate() {
        _value = GetValue(AttributeValueType.Base);
        SetValue(AttributeValueType.Base, GetValue(AttributeValueType.Default));
    }

    public virtual T Value {
        get { return _value; }
    }

    public override void SetAttributeParam(BaseAttributeParam p) {
        var att = BaseAttributeParam.Cast<AttributeParam<T>>(p);
        SetValue(att.attributeValueType, att.value);
    }
}