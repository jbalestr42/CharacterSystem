using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NotSilencedReq : IRequirement {

	public bool IsValid(GameObject p_owner) {
		return p_owner.GetComponent<AttributeManager>().GetAttribute<bool>(AttributeType.CanUseSkill).Value;
	}
}