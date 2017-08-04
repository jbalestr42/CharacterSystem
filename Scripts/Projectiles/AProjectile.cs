using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AProjectile : MonoBehaviour {

	Character _owner;

	void Update() {
		UpdateMovement(_owner);
	}

	public virtual void Init(Character p_owner) {
		_owner = p_owner;
	}

	void OnTriggerEnter2D(Collider2D p_collider) {
		Debug.Log("Trigger");
		OnHit(_owner, p_collider);
	}

	public abstract void OnHit(Character p_owner, Collider2D p_collider);
	public abstract void UpdateMovement(Character p_owner);
}