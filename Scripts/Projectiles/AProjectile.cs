using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AProjectile : MonoBehaviour {

    GameObject _owner;

	void Update() {
		UpdateMovement(_owner);
	}

	public virtual void Init(GameObject p_owner) {
		_owner = p_owner;
    }

    void OnTriggerEnter2D(Collider2D p_collider) {
        OnHit(_owner, p_collider);
    }

    void OnCollisionEnter(Collision p_collider) {
        OnHit(_owner, p_collider);
    }

    public virtual void OnHit(GameObject p_owner, Collider2D p_collider) { }
    public virtual void OnHit(GameObject p_owner, Collision p_collider) { }
    public abstract void UpdateMovement(GameObject p_owner);
}