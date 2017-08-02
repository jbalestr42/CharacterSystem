using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class StatManager : MonoBehaviour {
	
	public Dictionary<StatType, Stat> m_stats = new Dictionary<StatType, Stat>();

	void Update() {
		foreach (KeyValuePair<StatType, Stat> stat in m_stats)
			stat.Value.Update(gameObject);
	}

	void OnGUI() {
		GUI.Label(new Rect(10, 10, 500, 20), "Stats : ");
		int i = 2;
		foreach (KeyValuePair<StatType, Stat> stat in m_stats) {
			string s = stat.Key.ToString() + " : " + stat.Value.ToString();
			GUI.Label(new Rect(10, 15 * i++, 500, 20), s);
		}
	}

	public void AddStat(StatType p_statType, Stat p_stat) {
		m_stats.Add(p_statType, p_stat);
	}

	public Stat GetStat(StatType p_type) {
		return m_stats[p_type];
	}

	public void AddModifier(StatType p_statType, StatModifier p_stateModifier) {
		if (m_stats.ContainsKey(p_statType))
			m_stats[p_statType].AddModifier(p_stateModifier);
	}

	public void RemoveModifier(StatType p_statType, StatModifier p_stateModifier) {
		if (m_stats.ContainsKey(p_statType))
			m_stats[p_statType].RemoveModifier(p_stateModifier);
	}
}
