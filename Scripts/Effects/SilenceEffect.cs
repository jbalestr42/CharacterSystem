using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SilenceEffect : ADurationEffect {

	public SilenceEffect(float p_duration)
		:base(p_duration) {
	}

	public override void OnStart(GameObject p_target) {	
		p_target.GetComponent<Character>().CanUseSkill = false;
	}

	public override void OnEnd(GameObject p_target) {
		p_target.GetComponent<Character>().CanUseSkill = true;
	}

	protected override void UpdateEffect(GameObject p_target, float p_duration) {
		p_target.GetComponent<Character>().CanUseSkill = false;
	}
}