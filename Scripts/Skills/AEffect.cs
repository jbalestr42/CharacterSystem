using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AEffect {

	float _duration;

	public AEffect(float p_duration) {
		_duration = p_duration;
	}
	
	// Update is called once per frame
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

public class Silence : AEffect {

	public Silence()
		:base(2.0f) {
	}

	public override void OnEffectStart(GameObject p_target) {
		p_target.GetComponent<Character>().CanUseSkill = false;
	}

	public override void OnEffectEnd(GameObject p_target) {
		p_target.GetComponent<Character>().CanUseSkill = true;
	}

	protected override void UpdateEffect(GameObject p_target) {
		p_target.GetComponent<Character>().CanUseSkill = false;
	}
}