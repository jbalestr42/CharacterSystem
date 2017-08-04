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

	public abstract void UpdateMovement(Character p_owner);
}