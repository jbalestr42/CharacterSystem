using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Stat {

	// TODO use vector instead of dictionnary with enum as index
    private Dictionary<StatValueType, float> _values;
    private List<AStatModifier> _modifiers;
    private float _total;

    public Stat(float p_value, float p_min, float p_max) {
        _values = new Dictionary<StatValueType, float>();
        _values.Add(StatValueType.Base, p_value);
        _values.Add(StatValueType.AbsoluteBonus, 0f);
        _values.Add(StatValueType.RelativeBonus, 0f);
        _values.Add(StatValueType.Min, p_min);
        _values.Add(StatValueType.Max, p_max);
        _modifiers = new List<AStatModifier>();
        ComputeTotal();
    }

	public void Update(GameObject p_owner) {
		Reset();
        UpdateModifier(p_owner);
		ComputeTotal();
    }

    void Reset() {
        _values[StatValueType.RelativeBonus] = 0;
        _values[StatValueType.AbsoluteBonus] = 0;
    }

    void UpdateModifier(GameObject p_owner) {
        for (int i = _modifiers.Count - 1; i >= 0; i--) {
            _modifiers[i].Apply(this, p_owner);
			if (_modifiers[i].IsOver()) {
				_modifiers[i].OnEffectEnd(p_owner);
				_modifiers.RemoveAt(i);
			}
        }
    }

	void ComputeTotal() {
        _total = (_values[StatValueType.Base] + _values[StatValueType.AbsoluteBonus]) * (1f + _values[StatValueType.RelativeBonus]);
        _total = Mathf.Clamp(_total, _values[StatValueType.Min], _values[StatValueType.Max]);
    }

    public float Total {
        get { return _total; }
    }

    public void Add(StatValueType p_type, float p_value) {
		if (_values.ContainsKey(p_type)) {
			_values[p_type] += p_value;
		}
    }

    public float GetValue(StatValueType p_type) {
        return _values[p_type];
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