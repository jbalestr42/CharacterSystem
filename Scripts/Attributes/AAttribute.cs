using System.Collections;
using System.Collections.Generic;
using UnityEngine.Assertions;
using UnityEngine;

/// <summary>
/// The abstract class to manage an attribute
/// An attribute is a value that can be modified by AttributeModifiers in real time
/// It can contains multiple values that help compute a final value based on the modifiers at each frame
/// </summary>
public abstract class AAttribute {

    /// The list of attributes modifier
    private List<AttributeModifier> _modifiers;

    public AAttribute() {
        _modifiers = new List<AttributeModifier>();
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
    /// This method is called after applying the modifiers
    /// Compute the final value
    /// </summary>
    public abstract void AfterModifierUpdate();

    /// <summary>
    /// Set an AttributeParam, an attribute param is a value that help computing the final value
    /// </summary>
    /// <param name="p"></param>
    public abstract void SetAttributeParam(BaseAttributeParam p);

    /// <summary>
    /// Update the modifiers
    /// </summary>
    /// <param name="p_owner">The owner of the AAttribute</param>
    void UpdateModifier(GameObject p_owner) {
        for (int i = _modifiers.Count - 1; i >= 0; i--) {
            _modifiers[i].Update(p_owner);
            if (_modifiers[i].IsOver()) {
                _modifiers[i].OnEnd(p_owner);
                _modifiers.RemoveAt(i);
            }
        }
    }

    /// <summary>
    /// Add a modifier to this attribute
    /// </summary>
    /// <param name="p_attributeeModifier">The new modifier</param>
    public void AddModifier(AttributeModifier p_attributeeModifier) {
        _modifiers.Add(p_attributeeModifier);
    }

    /// <summary>
    /// Remove a modifier to this attribute
    /// </summary>
    /// <param name="p_attributeeModifier">The modifier to remove</param>
    public void RemoveModifier(AttributeModifier p_attributeeModifier) {
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
        Assert.IsNotNull(value);
        return value;
    }
}