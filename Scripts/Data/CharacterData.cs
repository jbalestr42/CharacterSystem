using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CharacterData : ScriptableObject
{
	[System.Serializable]
	public struct StatModifierData
	{
		public StatModifierType statModifierType;
		public AStatModifierFactor.Attribute modifierFactorAttributes;
		public StatValueType statValueType;
		public float value;
	}

    [System.Serializable]
    public struct StatData
    {
        public StatType valueType;
        public float baseValue;
        public float min;
		public float max;
		public List<StatModifierData> statModifiers;
    }

	public MovementType _movementType;
	public List<StatData> _stats;

	[UnityEditor.MenuItem("Assets/Create/CharacterData")]
	public static void CreateAsset()
	{
		ScriptableObjectUtility.CreateAsset<CharacterData>();
	}
}