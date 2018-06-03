using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleProjectile : AProjectile {

	public float _speed = 10.0f;
	public float _damage = 3.0f;

    Vector3 _direction;

    public override void Init(Character p_owner) {
        base.Init(p_owner);
        _direction = GameObject.Find("Character").transform.position - transform.position;
        _direction.Normalize();
    }

	public override void UpdateMovement(Character p_owner) {
	    transform.position += _direction * _speed * Time.deltaTime;
	}

	public override void OnHit(Character p_owner, Collider2D p_collider) {
		IKillable chara = p_collider.gameObject.GetComponent<IKillable>();
		if (p_collider.gameObject != p_owner.gameObject) {
			if (chara != null) {
				chara.GetDamage(p_owner.gameObject, _damage + p_owner.GetComponent<AttributeManager>().GetAttribute<float>(AttributeType.Damage).Value);

                var attribute = new AttributeParam<float>(p_collider.gameObject.GetComponent<Character>()._iconGroup.Add(Color.yellow, true), 0, false, 3f, -1f, AttributeType.Speed, AttributeValueType.RelativeBonus);
                var modifier = AttributeModifier.GetModifier(AttributModifierType.DurationRatio, p_collider.gameObject, attribute);
                p_collider.gameObject.GetComponent<AttributeManager>().AddModifier(modifier);
            }
			Destroy(gameObject);
		}
	}
}