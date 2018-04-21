using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectManager : MonoBehaviour {

	List<IEffect> _effects;

	void Start() {
		_effects = new List<IEffect>();
	}
	
	void Update() {
		for (int i = _effects.Count - 1; i >= 0 ; i--) {
			_effects[i].Update(gameObject);
			if (_effects[i].IsOver()) {
				_effects[i].OnEnd(gameObject);
				_effects.RemoveAt(i);
			}
		}
	}

	public void AddEffect(IEffect p_effect) {
		p_effect.OnStart(gameObject);
		_effects.Add(p_effect);
	}
}
