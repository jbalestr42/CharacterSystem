using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ARequirement {
	public abstract bool IsValid(Character p_owner);
}