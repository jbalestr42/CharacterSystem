using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputReq : IRequirement {

	string _key;

	public InputReq(string p_key) {
		_key = p_key;
	}

	public bool IsValid(GameObject p_owner) {
		if (Input.GetKey(_key)) {	
			return true;
		}
		return false;
	}
}