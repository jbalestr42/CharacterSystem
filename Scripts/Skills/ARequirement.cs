using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ARequirement {
	public abstract bool IsValid(Character p_owner);
}

public class InputReq : ARequirement {

	public override bool IsValid(Character p_owner) {
		//if (p_owner.GetInput("space").IsKeyPress())
		return true;
	}
}

public class IsNotSilenceReq : ARequirement {

	public override bool IsValid(Character p_owner) {
		return p_owner.CanUseSkill;
	}
}