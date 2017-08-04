using UnityEngine;
using System.Collections.Generic;
using System;

public abstract class AStatModifierFactor {

	[System.Serializable]
	public struct Attribute
	{
		public int count;
		public bool inverse;
		public float duration;
	}

	protected Attribute _attributes;

	public virtual void Init(Character p_owner, Attribute p_attribute) {
		_attributes = p_attribute;
	}

	public virtual bool IsOver() {
		return false;
	}

	public abstract float GetFactor(GameObject p_character);

}

public class HealthRatio : AStatModifierFactor {

	public override float GetFactor(GameObject p_owner) {
		float factor = p_owner.GetComponent<Character>().Health.GetRatio();
		if (_attributes.inverse) {
			return 1.0f - factor;
		}
		return factor;
	}
}

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

public class DamageCounter : AStatModifierFactor {

	int _damageCount;

	public override void Init(Character p_owner, Attribute p_attribute) {
		_damageCount = 0;
		_attributes = p_attribute;
		p_owner.Suscribe(EventType.OnGetDamaged, OnGetDamaged);
	}

	public override float GetFactor(GameObject p_character) {
		return (_damageCount);
	}

	public void OnGetDamaged(GameObject p_owner) {
		_damageCount++;
	}
}

/*

public class InRange : AStatModifierFactor {
	
    public override float GetFactor(GameObject p_character) {
        return 12;//p_character.GetComponent<Characher>().GetInRange(_tag);
    }
}
*/