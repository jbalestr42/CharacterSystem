﻿using UnityEngine;
using System.Collections.Generic;
using UnityEngine.Assertions;

/// <summary>
/// Contains all the attributes, provide helper methods to add and remove modifiers
/// </summary>
[DisallowMultipleComponent]
public class AttributeManager : MonoBehaviour
{
    public Dictionary<int, AAttribute> _attributes = new Dictionary<int, AAttribute>();

    void Update()
    {
        foreach (KeyValuePair<int, AAttribute> attribute in _attributes)
        {
            attribute.Value.Update(gameObject);
        }
    }

    public void AddAttribute(int p_attributeType, AAttribute p_stat)
    {
        Assert.IsFalse(_attributes.ContainsKey(p_attributeType), "Key already exists: " + p_attributeType);

        _attributes.Add(p_attributeType, p_stat);
        p_stat.Update(gameObject);
    }

    public Attribute<T> GetAttribute<T>(int p_attributeType)
    {
        Assert.IsTrue(_attributes.ContainsKey(p_attributeType), "Key doesn't exists: " + p_attributeType);

        Attribute<T> attribute = AAttribute.Cast<Attribute<T>>(_attributes[p_attributeType]);
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
