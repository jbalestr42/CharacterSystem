using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SilenceEffect : AEffect {

	public SilenceEffect(float _duration)
		:base(_duration) {
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