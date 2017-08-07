using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Counter : AStatModifier {

	int _damageCount;

	public override void OnEffectStart(GameObject p_owner, Attribute p_attribute) {
		_damageCount = 0;
		_attributes = p_attribute;
		p_owner.GetComponent<Character>().Suscribe(EventType.OnGetDamaged, OnGetDamaged);
	}

	public override float GetFactor(GameObject p_owner) {
		return (1.0f);
	}

	public override bool IsOver() {
		return _damageCount >= _attributes.count;
	}

	public override void OnEffectEnd(GameObject p_owner) {
		p_owner.GetComponent<Character>().Unsuscribe(EventType.OnGetDamaged, OnGetDamaged);
	}

	public void OnGetDamaged(GameObject p_owner) {
		_damageCount++;
	}
}