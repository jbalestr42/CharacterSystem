using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IRequirement {
	bool IsValid(GameObject p_owner);
}