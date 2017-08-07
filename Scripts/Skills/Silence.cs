using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// TODO this skill can be generic (AddEffectSkill)
// and add any kind of effect for a certain duration using an enum and a factory
public class Silence : ASkill {

	void Start() {
		List<ARequirement> requirement = new List<ARequirement>();
		requirement.Add(new InputReq("tab"));
		// TODO ligne de vision entre le joueur et la cible ?
		base.Init(0.0f, 5.0f, requirement);
	}

	public override void Cast(Character p_owner) {
		GameObject target = p_owner.GetTarget();
		target.GetComponent<EffectManager>().AddEffect(new SilenceEffect(2.0f));
	}
}
