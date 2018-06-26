using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotProjectileIA : ASkill {

	public GameObject _bullet;

	void Start() {
        var requirement = new List<IRequirement>();
        requirement.Add(new VisionReq(gameObject, GameObject.Find("Character")));
        base.Init(0.1f, 2.0f, requirement, GetComponent<Character>()._skillGroup.Add(Color.cyan, true));
	}

	public override void Cast(GameObject p_owner) {
		GameObject bullet = Instantiate(_bullet, p_owner.transform.position, p_owner.transform.rotation);
		bullet.GetComponent<AProjectile>().Init(p_owner);
	}
}