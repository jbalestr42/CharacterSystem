using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomingProjectile : AProjectile {

	public float _speed = 5.0f;
	public float _damage = 3.0f;

	public override void UpdateMovement(Character p_owner) {
		GameObject target = p_owner.GetTarget();
		if (target != null) {
			Vector3 direction = (target.transform.position - transform.position).normalized;
			transform.position += direction * _speed * Time.deltaTime;
		}
	}

	public override void OnHit(Character p_owner, Collider2D p_collider) {
		Debug.Log("Collision with " + p_collider.gameObject.name);
		IKillable chara = p_collider.gameObject.GetComponent<IKillable>();
		if (p_collider.gameObject != p_owner.gameObject) {
			if (chara != null) {
				chara.GetDamage(p_owner.gameObject, _damage + p_owner.GetStat(StatType.Damage).Total);
			}
			Destroy(gameObject);
		}
	}
}