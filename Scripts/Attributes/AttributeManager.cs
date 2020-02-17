using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// Contains all the attributes, provide helper methods to add and remove modifiers
/// </summary>
public class AttributeManager : MonoBehaviour
{
    public Dictionary<int, AAttribute> _attributes = new Dictionary<int, AAttribute>();

    void Update()
    {
        foreach (var attribute in _attributes)
        {
            attribute.Value.Update(gameObject);
        }
    }

    public void AddAttribute(int p_attributeType, AAttribute p_stat)
    {
        _attributes.Add(p_attributeType, p_stat);
        p_stat.Update(gameObject);
    }

    public Attribute<T> GetAttribute<T>(int p_type)
    {
        Attribute<T> attribute = AAttribute.Cast<Attribute<T>>(_attributes[p_type]);
        if (attribute != null)
        {
            return attribute;
        }
        return null;
    }

    public void AddModifier(IAttributeModifier p_attributeModifier)
    {
        if (_attributes.ContainsKey(p_attributeModifier.GetAttributeType()))
        {
            _attributes[p_attributeModifier.GetAttributeType()].AddModifier(p_attributeModifier);
        }
    }

    public void RemoveModifier(IAttributeModifier p_stateModifier)
    {
        if (_attributes.ContainsKey(p_stateModifier.GetAttributeType()))
        {
            _attributes[p_stateModifier.GetAttributeType()].RemoveModifier(p_stateModifier);
        }
    }
}
