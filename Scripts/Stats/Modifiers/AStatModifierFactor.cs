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