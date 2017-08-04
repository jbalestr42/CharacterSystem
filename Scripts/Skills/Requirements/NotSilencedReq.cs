using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NotSilencedReq : ARequirement {

	public override bool IsValid(Character p_owner) {
		return p_owner.CanUseSkill;
	}
}