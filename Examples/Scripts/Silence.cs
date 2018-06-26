using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// TODO this skill can be generic (AddEffectSkill)
// and add any kind of effect for a certain duration using an enum and a factory

// We cana lso make a generic one frame skill (e.g. cleans: clean all negative effects and remove all negative modifiers)

public class Silence : ASkill {

	void Start() {
		var requirement = new List<IRequirement>();
		requirement.Add(new InputReq("tab"));
		// TODO ligne de vision entre le joueur et la cible ?
		base.Init(0.1f, 5.0f, requirement, GetComponent<Character>()._skillGroup.Add(Color.cyan, true));
	}

	public override void Cast(GameObject p_owner) {
		GameObject target = p_owner.GetComponent<Character>().GetTarget();

        AttributeParam<bool> attribute = new AttributeParam<bool>();
        attribute.value = false;
        attribute.duration = 3f;
        attribute.attributeType = AttributeType.CanUseSkill;
        attribute.attributeValueType = AttributeValueType.Base;
        target.GetComponent<AttributeManager>().AddModifier(AttributeModifier.GetModifier(AttributModifierType.Duration, target, attribute));
	}
}
