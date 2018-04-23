using UnityEngine;

public class DurationRatio : Duration {

	public override void Update(GameObject p_owner) {
        Param.factor = GetRatio();
		if (Param.inverse) {
            Param.factor = 1f - Param.factor;
		}

        p_owner.GetComponent<AttributeManager>().SetAttributeParam(Param);
    }
}