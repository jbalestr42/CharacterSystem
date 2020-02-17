using System.Collections.Generic;

/// <summary>
/// Generic attribute class
/// Allow to create an attribute for the specify type T
/// 
/// The purpose of this class is to compute a value based on multiple other values
/// </summary>
public class Attribute<T> : AAttribute
{
    /// The values needed by the attribute to compute the final value
    Dictionary<int, T> _values = new Dictionary<int, T>();

    /// The final value once the modifier are applyed
    T _value;

    public Attribute()
        : this(default(T)) { }

    public Attribute(T p_value)
    {
        SetValue(AttributeValueType.Base, p_value);
        SetValue(AttributeValueType.Default, p_value);
    }

    /// <summary>
    /// Return a value contained in the dictionnary
    /// </summary>
    /// <param name="p_type">The requested AttributeValueType</param>
    /// <returns>The value associated to p_type</returns>
    public T GetValue(int p_type)
    {
        return _values[p_type];
    }

    /// <summary>
    /// Set an AttributeValueType
    /// </summary>
    /// <param name="p_type">The AttributeValueType to set</param>
    /// <param name="p_value">The value to set</param>
    public void SetValue(int p_type, T p_value)
    {
        _values[p_type] = p_value;
    }

    /// <summary>
    /// This method is called after applying the modifiers
    /// Set the final value and reset the base value to default
    /// </summary>
    public override void AfterModifierUpdate()
    {
        _value = GetValue(AttributeValueType.Base);
        SetValue(AttributeValueType.Base, GetValue(AttributeValueType.Default));
    }

    /// <summary>
    /// Get the final value once the modfier are applyed and the method AfterModifierUpdate is applyed
    /// </summary>
    public virtual T Value
    {
        get { return _value; }
    }
}