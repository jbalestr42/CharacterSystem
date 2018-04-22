using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ABaseAttribute {

    private List<AttributeModifier> _modifiers;

    public ABaseAttribute() {
        _modifiers = new List<AttributeModifier>();
    }

    public virtual void Update(GameObject p_owner) {
        UpdateModifier(p_owner);
        AfterModifierUpdate();
    }

    public abstract void AfterModifierUpdate();

    void UpdateModifier(GameObject p_owner) {
        for (int i = _modifiers.Count - 1; i >= 0; i--) {
            _modifiers[i].Update(p_owner);
            if (_modifiers[i].IsOver()) {
                _modifiers[i].OnEnd(p_owner);
                _modifiers.RemoveAt(i);
            }
        }
    }

    public void AddModifier(AttributeModifier p_attributeeModifier) {
        _modifiers.Add(p_attributeeModifier);
    }

    public void RemoveModifier(AttributeModifier p_attributeeModifier) {
        _modifiers.Remove(p_attributeeModifier);
    }
}