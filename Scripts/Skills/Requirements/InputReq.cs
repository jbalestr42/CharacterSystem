using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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