using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotProjectileTower : ASkill {

	public GameObject _bullet;

	void Start() {
        var requirement = new List<IRequirement>();
        requirement.Add(new ValidTargetReq(gameObject));
        Attribute<float> rate = GetComponent<AttributeManager>().GetAttribute<float>(AttributeType.AttackRate);
        base.Init(0.1f, rate.Value, requirement, null);
    }

	public override void Cast(GameObject p_owner) {
		GameObject bullet = Instantiate(_bullet, p_owner.transform.position, p_owner.transform.rotation);
		bullet.GetComponent<AProjectile>().Init(p_owner);
	}
}