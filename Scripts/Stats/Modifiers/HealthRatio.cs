using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthRatio : AStatModifier {

	public override float GetFactor(GameObject p_owner) {
		float factor = p_owner.GetComponent<Character>().Health.GetRatio();
		if (_attributes.inverse) {
			return 1.0f - factor;
		}
		return factor;
	}
}