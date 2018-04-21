using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CharacterData : ScriptableObject
{
	[System.Serializable]
	public struct StatModifierData
	{
		// TODO use inheritance to get the good attributes
		public StatModifierType statModifierType;
		public ModifierAttribute modifierFactorAttributes;
	}

    [System.Serializable]
    public struct StatData
    {
        public int valueType;
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