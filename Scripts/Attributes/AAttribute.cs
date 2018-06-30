using System.Collections;
using System.Collections.Generic;
using UnityEngine.Assertions;
using UnityEngine;

/// <summary>
/// The abstract class to manage an attribute
/// An attribute is a value that can be modified by AttributeModifiers in real time
/// </summary>
public abstract class AAttribute {

    /// The list of attributes modifier
    private List<IAttributeModifier> _modifiers;

    public AAttribute() {
        _modifiers = new List<IAttributeModifier>();
    }

    /// <summary>
    /// Called each frame, this method usually don?t need to be override
    /// Update the attribute values based on the modifiers and compute the final value
    /// </summary>
    /// <param name="p_owner"></param>
    public virtual void Update(GameObject p_owner) {
        UpdateModifier(p_owner);
        AfterModifierUpdate();
    }

    /// <summary>
    /// Apply the modifiers
    /// </summary>
    /// <param name="p_owner">The owner of the AAttribute</param>
    void UpdateModifier(GameObject p_owner) {
        for (int i = _modifiers.Count - 1; i >= 0; i--) {
            _modifiers[i].ApplyModifier(p_owner, this);
            if (_modifiers[i].IsOver()) {
                _modifiers[i].OnEnd(p_owner);
                _modifiers.RemoveAt(i);
            }
        }
    }

    /// <summary>
    /// This method is called after applying the modifiers
    /// It's used to do special computation once the modifiers are applyed
    /// </summary>
    public abstract void AfterModifierUpdate();

    /// <summary>
    /// Add a modifier to this attribute
    /// </summary>
    /// <param name="p_attributeeModifier">The new modifier</param>
    public void AddModifier(IAttributeModifier p_attributeeModifier) {
        _modifiers.Add(p_attributeeModifier);
    }

    /// <summary>
    /// Remove a modifier from this attribute
    /// </summary>
    /// <param name="p_attributeeModifier">The modifier to remove</param>
    public void RemoveModifier(IAttributeModifier p_attributeeModifier) {
        _modifiers.Remove(p_attributeeModifier);
    }

    /// <summary>
    /// Helper method to downcast the attribute
    /// </summary>
    /// <typeparam name="T">The destination type</typeparam>
    /// <param name="p_value">The value to downcast</param>
    /// <returns>The casted value</returns>
    public static T Cast<T>(AAttribute p_value) where T : AAttribute {
        T value = (T)p_value;
        Assert.IsNotNull(value); // TODO Add error message
        return value;
    }
}