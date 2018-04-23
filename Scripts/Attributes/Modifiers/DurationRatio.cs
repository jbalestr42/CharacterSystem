using UnityEngine;

public class DurationRatio : Duration {

	public override void Update(GameObject p_owner) {
		Attributes.factor = GetRatio();
		if (Attributes.inverse) {
            Attributes.factor = 1f - Attributes.factor;
		}

        p_owner.GetComponent<AttributeManager>().SetAttribute(Attributes);
    }
}