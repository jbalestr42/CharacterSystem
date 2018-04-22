using UnityEngine;

public class DurationRatio : Duration {

	public override void Update(GameObject p_owner) {
		float factor = GetRatio();
		if (Attributes.inverse) {
			factor = 1f - factor;
		}

        Attribute<float> attribute = p_owner.GetComponent<AttributeManager>().GetAttribute<float>(Attributes.attributeType);
        attribute.SetValue(Attributes.attributeValueType, attribute.GetValue(Attributes.attributeValueType) + Attributes.value * factor);
    }
}