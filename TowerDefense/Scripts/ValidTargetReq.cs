using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ValidTargetReq : IRequirement {

    GameObject _owner;

    public ValidTargetReq(GameObject p_owner) {
        _owner = p_owner;
    }

	public bool IsValid(GameObject p_owner) {
        return (_owner.GetComponent<Tower>().GetTarget());
	}
}