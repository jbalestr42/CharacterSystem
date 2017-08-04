using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DurationRatio : AStatModifierFactor {

	float _endOfEffect;

	public override void Init(Character p_owner, Attribute p_attribute) {
		_attributes = p_attribute;
		_endOfEffect = Time.realtimeSinceStartup + _attributes.duration;
	}

	public override bool IsOver() {
		return (_endOfEffect - Time.realtimeSinceStartup) <= 0.0f;
	}

	public override float GetFactor(GameObject p_owner) {
		float factor = Mathf.Clamp((_endOfEffect - Time.realtimeSinceStartup) / _attributes.duration, 0.0f, 1.0f);
		if (_attributes.inverse) {
			return (1 - factor);
		}
		return (factor);
	}
}