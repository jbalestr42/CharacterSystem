using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageCounter : AStatModifierFactor {

	int _damageCount;

	public override void Init(Character p_owner, Attribute p_attribute) {
		_damageCount = 0;
		_attributes = p_attribute;
		p_owner.Suscribe(EventType.OnGetDamaged, OnGetDamaged);
	}

	public override float GetFactor(GameObject p_character) {
		return (_damageCount);
	}

	public void OnGetDamaged(GameObject p_owner) {
		_damageCount++;
	}
}