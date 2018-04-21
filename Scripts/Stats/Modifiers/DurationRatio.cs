using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DurationRatio : Duration {

	public override float GetFactor(GameObject p_owner) {
		float factor = Mathf.Clamp(GetRatio(), 0.0f, 1.0f);
		if (Attribute.inverse) {
			return (1 - factor);
		}
		return (factor);
	}
}