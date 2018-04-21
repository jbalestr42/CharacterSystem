using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Counter : AStatModifier {

	int _damageCount;

	public override void OnStart(GameObject p_owner) {
		_damageCount = 0;
		p_owner.GetComponent<Character>().Suscribe(EventType.OnGetDamaged, OnGetDamaged);
	}

	public override float GetFactor(GameObject p_owner) {
		return 1f;
	}

	public override bool IsOver() {
		return _damageCount >= Attribute.count;
	}

	public override void OnEnd(GameObject p_owner) {
		p_owner.GetComponent<Character>().Unsuscribe(EventType.OnGetDamaged, OnGetDamaged);
	}

	public void OnGetDamaged(GameObject p_owner) {
		_damageCount++;
	}
}