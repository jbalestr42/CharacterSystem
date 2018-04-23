using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Counter : AttributeModifier {

	int _damageCount;

	public override void OnStart(GameObject p_owner) {
		_damageCount = 0;
		p_owner.GetComponent<Character>().Suscribe(EventType.OnGetDamaged, OnGetDamaged);
	}

    public override void Update(GameObject p_owner) {
        // TODO tredo
        //Attribute<float> attribute = p_owner.GetComponent<AttributeManager>().GetAttribute<float>(Attributes.attributeType);
        //attribute.SetValue(Attributes.attributeValueType, attribute.GetValue(Attributes.attributeValueType) + Attributes.value);
    }

    public override bool IsOver() {
		return _damageCount >= Attributes.count;
	}

	public override void OnEnd(GameObject p_owner) {
		p_owner.GetComponent<Character>().Unsuscribe(EventType.OnGetDamaged, OnGetDamaged);
	}

	public void OnGetDamaged(GameObject p_owner) {
		_damageCount++;
	}
}