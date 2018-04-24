using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CharacterData : ScriptableObject
{
	[System.Serializable]
	public struct AttributModifierData
	{
		// TODO use inheritance to get the good attributes
		public AttributModifierType AttributModifierType;
		public AttributeParam<float> modifierFactorAttributes;
	}

    [System.Serializable]
    public struct AttributeData
    {
        public int valueType;
        public float baseValue;
        public float min;
		public float max;
		public List<AttributModifierData> AttributModifiers;
    }

	public MovementType _movementType;
	public List<AttributeData> _attributes;

    [UnityEditor.MenuItem("Assets/Create/CharacterData")]
	public static void CreateAsset()
	{
		ScriptableObjectUtility.CreateAsset<CharacterData>();
	}
}