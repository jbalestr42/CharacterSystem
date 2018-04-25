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
				chara.GetDamage(p_owner.gameObject, _damage + p_owner.GetComponent<AttributeManager>().GetAttribute<float>(AttributeType.Damage).Value);

                // TODO apply the onhit effect from the owner to the target
                // And the damage is a onhit effect
                var attribute = new AttributeParam<float>(p_collider.gameObject.GetComponent<Character>()._iconGroup.Add(Color.yellow, true), 0, false, 3f, -1f, AttributeType.Speed, AttributeValueType.RelativeBonus);
                var modifier = AttributeModifier.GetModifier(AttributModifierType.DurationRatio, p_collider.gameObject, attribute);
                p_collider.gameObject.GetComponent<AttributeManager>().AddModifier(modifier);
            }
			Destroy(gameObject);
		}
	}
}