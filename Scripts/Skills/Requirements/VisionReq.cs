using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisionReq : IRequirement {

    GameObject _owner;
    GameObject _target;

    public VisionReq(GameObject p_owner, GameObject p_target) {
        _owner = p_owner;
        _target = p_target;
    }

	public bool IsValid(GameObject p_owner) {
        var start = new Vector2(_owner.transform.position.x, _owner.transform.position.y);
        var end = new Vector2(_target.transform.position.x, _target.transform.position.y);
        RaycastHit2D hit = Physics2D.Linecast(start, end, 1 << 9);
        return (hit.transform == null);
	}
}