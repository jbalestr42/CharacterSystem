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

	protected Attribute m_attributes;

	public virtual void Init(Character p_owner, Attribute p_attribute) {
		m_attributes = p_attribute;
	}

	public virtual bool IsOver() {
		return false;
	}

	public abstract float GetFactor(GameObject p_character);

}

public class HealthRatio : AStatModifierFactor {

	public override float GetFactor(GameObject p_owner) {
		float factor = p_owner.GetComponent<Character>().Health.GetRatio();
		if (m_attributes.inverse) {
			return 1.0f - factor;
		}
		return factor;
	}
}

public class DurationRatio : AStatModifierFactor {

	float m_endOfEffect;

	public override void Init(Character p_owner, Attribute p_attribute) {
		m_attributes = p_attribute;
		m_endOfEffect = Time.realtimeSinceStartup + m_attributes.duration;
	}

	public override bool IsOver() {
		return (m_endOfEffect - Time.realtimeSinceStartup) <= 0.0f;
	}

	public override float GetFactor(GameObject p_owner) {
		float factor = Mathf.Clamp((m_endOfEffect - Time.realtimeSinceStartup) / m_attributes.duration, 0.0f, 1.0f);
		if (m_attributes.inverse) {
			return (1 - factor);
		}
		return (factor);
	}
}

public class DamageCounter : AStatModifierFactor {

	int m_damageCount;

	public override void Init(Character p_owner, Attribute p_attribute) {
		m_damageCount = 0;
		m_attributes = p_attribute;
		p_owner.Suscribe(EventType.OnGetDamaged, OnGetDamaged);
	}

	public override float GetFactor(GameObject p_character) {
		return (m_damageCount);
	}

	public void OnGetDamaged(GameObject p_owner) {
		m_damageCount++;
	}
}

/*

public class InRange : AStatModifierFactor {
	
    public override float GetFactor(GameObject p_character) {
        return 12;//p_character.GetComponent<Characher>().GetInRange(m_tag);
    }
}
*/