using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Counter : AStatModifierFactor {

	int _damageCount;

	public override void Init(Character p_owner, Attribute p_attribute) {
		_damageCount = 0;
		_attributes = p_attribute;
		p_owner.Suscribe(EventType.OnGetDamaged, OnGetDamaged);
	}

	public override float GetFactor(GameObject p_owner) {
		return (1.0f);
	}

	public override bool IsOver() {
		return _damageCount >= _attributes.count;
	}

	public override void OnRemoved(GameObject p_owner) {
		p_owner.GetComponent<Character>().Unsuscribe(EventType.OnGetDamaged, OnGetDamaged);
	}

	public void OnGetDamaged(GameObject p_owner) {
		_damageCount++;
	}
}