﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AStat {

    // TODO use vector instead of dictionnary with enum as index
    private Dictionary<int, float> _values;
    private List<AStatModifier> _modifiers;
    private float _total;

    public AStat() {
        _values = new Dictionary<int, float>();
        _modifiers = new List<AStatModifier>();
        _total = 0f;
    }

    public virtual void Update(GameObject p_owner) {
        Reset();
        UpdateModifier(p_owner);
        _total = ComputeTotal();
    }

    public abstract void Reset();
    public abstract float ComputeTotal();

    void UpdateModifier(GameObject p_owner) {
        for (int i = _modifiers.Count - 1; i >= 0; i--) {
            _modifiers[i].Apply(this, p_owner);
            if (_modifiers[i].IsOver()) {
                _modifiers[i].OnEnd(p_owner);
                _modifiers.RemoveAt(i);
            }
        }
    }

    public float Total {
        get { return _total; }
    }

    public void Add(int p_type, float p_value) {
        if (_values.ContainsKey(p_type)) {
            _values[p_type] += p_value;
        }
    }

    public float GetValue(int p_type) {
        return _values[p_type];
    }

    protected void SetValue(int p_type, float p_value) {
        _values[p_type] = p_value;
    }

    public void AddModifier(AStatModifier p_stateModifier) {
        _modifiers.Add(p_stateModifier);
    }

    public void RemoveModifier(AStatModifier p_stateModifier) {
        _modifiers.Remove(p_stateModifier);
    }

    public override string ToString() {
        return _modifiers.Count + " modifiers - " + _total + " = (" + _values[StatValueType.Base] + " + " + _values[StatValueType.AbsoluteBonus] + ") * (1 * " + _values[StatValueType.RelativeBonus] + ")";
    }
}