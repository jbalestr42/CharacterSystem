using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomingProjectile : AProjectile {

	public float _speed = 5.0f;

	public override void UpdateMovement(Character p_owner) {
		GameObject target = p_owner.GetTarget();
		if (target != null) {
			Vector3 direction = (target.transform.position - transform.position).normalized;
			transform.position += direction * _speed * Time.deltaTime;
		}
	}
}