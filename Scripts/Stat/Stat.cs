using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Stat
{
	// TODO use vector instead of dictionnary with enum as index
    private Dictionary<StatValueType, float> m_values;
    private List<StatModifier> m_modifiers;
    private float m_total;

    public Stat(float p_value, float p_min, float p_max) {
        m_values = new Dictionary<StatValueType, float>();
        m_values.Add(StatValueType.Base, p_value);
        m_values.Add(StatValueType.AbsoluteBonus, 0f);
        m_values.Add(StatValueType.RelativeBonus, 0f);
        m_values.Add(StatValueType.Min, p_min);
        m_values.Add(StatValueType.Max, p_max);
        m_modifiers = new List<StatModifier>();
        computeTotal();
    }

	public void Update(GameObject p_owner) {
        reset();
        UpdateModifier(p_owner);
        computeTotal();
    }

    void reset() {
        m_values[StatValueType.RelativeBonus] = 0;
        m_values[StatValueType.AbsoluteBonus] = 0;
    }

    void UpdateModifier(GameObject p_owner) {
        for (int i = m_modifiers.Count - 1; i >= 0; i--) {
            m_modifiers[i].Apply(this, p_owner);
			if (m_modifiers[i].IsOver()) {
				m_modifiers.RemoveAt(i);
			}
        }
    }

    void computeTotal() {
        m_total = (m_values[StatValueType.Base] + m_values[StatValueType.AbsoluteBonus]) * (1f + m_values[StatValueType.RelativeBonus]);
        m_total = Mathf.Clamp(m_total, m_values[StatValueType.Min], m_values[StatValueType.Max]);
    }

    public float Total {
        get { return m_total; }
    }

    public void add(StatValueType p_type, float p_value) {
		if (m_values.ContainsKey(p_type)) {
			m_values[p_type] += p_value;
		}
    }

    public float getValue(StatValueType p_type) {
        return m_values[p_type];
    }

    public void AddModifier(StatModifier p_stateModifier) {
        m_modifiers.Add(p_stateModifier);
    }

    public void RemoveModifier(StatModifier p_stateModifier) {
        m_modifiers.Remove(p_stateModifier);
    }

    public override string ToString() {
        return m_modifiers.Count + " modifiers - " + m_total + " = (" + m_values[StatValueType.Base] + " + " + m_values[StatValueType.AbsoluteBonus] + ") * (1 * " + m_values[StatValueType.RelativeBonus] + ")";
    }
}