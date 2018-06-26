using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotProjectile : ASkill {

	public GameObject _bullet;

	void Start() {
		var requirement = new List<IRequirement>();
		requirement.Add(new InputReq("space"));
		base.Init(1.0f, 5.0f, requirement);
	}

	public override void Cast(GameObject p_owner) {
		GameObject bullet = Instantiate(_bullet, p_owner.transform.position, p_owner.transform.rotation);
		bullet.GetComponent<AProjectile>().Init(p_owner);
	}
}
