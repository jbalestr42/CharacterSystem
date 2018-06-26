using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerProjectile : AProjectile {

    public float _speed = 5.0f;
    public float _damage = 3.0f;

    public override void UpdateMovement(GameObject p_owner) {
        GameObject target = p_owner.GetComponent<Tower>().GetTarget();
        if (target != null) {
            Vector3 direction = (target.transform.position - transform.position).normalized;
            transform.position += direction * _speed * Time.deltaTime;
        } else {
            Destroy(gameObject);
        }
    }

    public override void OnHit(GameObject p_owner, Collision p_collider) {
        IKillable enemy = p_collider.gameObject.GetComponent<IKillable>();
        if (enemy != null) {
            if (p_collider.gameObject != p_owner) {
                enemy.GetDamage(p_collider.gameObject, _damage + p_owner.GetComponent<AttributeManager>().GetAttribute<float>(AttributeType.Damage).Value);
                Destroy(gameObject);
            }
        }
    }
}