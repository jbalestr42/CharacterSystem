using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectManager : MonoBehaviour {

	//TODO utiliser un dico avec comme clé le type d'effet (Good, Bad, Neutre)
	List<AEffect> _effects;

	void Start() {
		_effects = new List<AEffect>();
	}
	
	void Update() {
		for (int i = _effects.Count - 1; i >= 0 ; i--) {
			_effects[i].Update(gameObject);
			if (_effects[i].IsEffectOver()) {
				_effects[i].OnEffectEnd(gameObject);
				_effects.RemoveAt(i);
			}
		}
	}

	public void AddEffect(AEffect p_effect) {
		p_effect.OnEffectStart(gameObject);
		_effects.Add(p_effect);
	}
}
