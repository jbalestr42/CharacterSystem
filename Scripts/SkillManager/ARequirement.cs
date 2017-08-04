using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ARequirement {
	public abstract bool IsValid(Character p_owner);
}

public class InputReq : ARequirement {

	string _key;

	public InputReq(string p_key) {
		_key = p_key;
	}

	public override bool IsValid(Character p_owner) {
		if (Input.GetKey(_key)) {	
			return true;
		}
		return false;
	}
}

public class IsNotSilenceReq : ARequirement {

	public override bool IsValid(Character p_owner) {
		return p_owner.CanUseSkill;
	}
}