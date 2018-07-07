using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Interface to manage an attribute modifier
/// </summary>
public interface IAttributeModifier {

    /// <summary>
    /// Called once the attribute modifier is added
    /// </summary>
    /// <param name="p_owner"></param>
    void OnStart(GameObject p_owner);

    /// <summary>
    /// Called once the attribute modifier is removed
    /// </summary>
    /// <param name="p_owner"></param>
    void OnEnd(GameObject p_owner);

    /// <summary>
    /// Determine whether the attribute modifier is over or not
    /// </summary>
    /// <returns></returns>
    bool IsOver();

    /// <summary>
    /// Set the attribute param
    /// </summary>
    /// <param name="p_params"></param>
    void SetAttributeParam(BaseAttributeParam p_params);

    /// <summary>
    /// Apply the modifier, this method is called by the attribute
    /// </summary>
    /// <param name="p_owner"></param>
    /// <param name="p_attribute"></param>
    void ApplyModifier(GameObject p_owner, AAttribute p_attribute);

    /// <summary>
    /// Return the attribute type
    /// </summary>
    /// <returns></returns>
    int GetAttributeType();
}