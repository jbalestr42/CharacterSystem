using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class StatManager : MonoBehaviour {
	
	public Dictionary<int, Stat> _stats = new Dictionary<int, Stat>();

	void Update() {
        foreach (var stat in _stats) {
            stat.Value.Update(gameObject);
        }
	}

	void OnGUI() {
		GUI.Label(new Rect(10, 10, 500, 20), "Stats : ");
		int i = 2;
		foreach (var stat in _stats) {
			string s = stat.Key.ToString() + " : " + stat.Value.ToString();
			GUI.Label(new Rect(10, 15 * i++, 500, 20), s);
		}
	}

	public void AddStat(int p_statType, Stat p_stat) {
		_stats.Add(p_statType, p_stat);
	}

	public Stat GetStat(int p_type) {
		return _stats[p_type];
	}

    public void AddModifier(int p_statType, AStatModifier p_stateModifier) {
        if (_stats.ContainsKey(p_statType)) {
            _stats[p_statType].AddModifier(p_stateModifier);
        }
    }

    public void RemoveModifier(int p_statType, AStatModifier p_stateModifier) {
        if (_stats.ContainsKey(p_statType)) {
            _stats[p_statType].RemoveModifier(p_stateModifier);
        }
    }
}
