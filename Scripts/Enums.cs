public enum StatValueType {
	Base,
	AbsoluteBonus,
	RelativeBonus,
	Min,
	Max
}

public enum StatType {
	HealthMax,
	HealthRegen,
	Damage,
	Speed,
	Luck,
	CooldownReduction
}

public enum StatModifierType {
	HealthRatio,
	DurationRatio,
	Counter
}

public enum EventType {
	OnGetDamaged,
	OnHit,
	OnDie,
	OnEnemyDie,
	OnGetItem
}

public enum MovementType {
	Player,
	Random
}