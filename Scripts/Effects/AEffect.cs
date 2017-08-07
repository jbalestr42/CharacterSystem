using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AEffect {

	float _duration;

	public AEffect(float p_duration) {
		_duration = p_duration;
	}
	
	public void Update(GameObject _target) {
		_duration -= Time.deltaTime;
		UpdateEffect(_target);
	}

	public virtual bool IsEffectOver() {
		return _duration <= 0.0f;
	}

	public abstract void OnEffectStart(GameObject p_target);
	public abstract void OnEffectEnd(GameObject p_target);
	protected abstract void UpdateEffect(GameObject p_target);
}