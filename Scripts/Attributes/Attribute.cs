using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Generic attribute class
/// Allow to create an attribute for the specify type T
/// 
/// The purpose of this class is to compute a value based on multiple other values
/// </summary>
public class Attribute<T> : AAttribute
{
	public delegate void OnValueChangedDelegate(Attribute<T> p_attribute);
    
    public OnValueChangedDelegate OnValueChanged = null;

    /// The values needed by the attribute to compute the final value
    Dictionary<int, T> _values = new Dictionary<int, T>();

    /// The final value once modifiers are applyed
    T _value;

    public Attribute()
        : this(default(T)) { }

    public Attribute(T p_value)
    {
        SetValue(AttributeValueType.Base, p_value);
        SetValue(AttributeValueType.Default, p_value);
    }
    
    /// <summary>
    /// Called each frame, this method usually don?t need to be override
    /// Update the attribute values based on the modifiers and compute the final value
    /// </summary>
    /// <param name="p_owner"></param>
    public override void Update(GameObject p_owner)
    {
        T value = Value;
        base.Update(p_owner);

        if (ShouldTriggerEvent() && !IsEqual(value) && OnValueChanged != null)
        {
            OnValueChanged.Invoke(this);
        }
    }
    
    /// <summary>
    /// Determine whether events should be triggered or not
    /// </summary>
    public virtual bool ShouldTriggerEvent()
    {
        return true;
    }
    
    /// <summary>
    /// Compare the given value with the current Value
    /// </summary>
    /// <param name="p_value">The value to compare with the current value</param>
    /// <returns>Return true if values are equal</returns>
    public virtual bool IsEqual(T p_value)
    {
        return p_value.Equals(Value);
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