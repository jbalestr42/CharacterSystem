public class StatValueType {
    public static int Base = 0;
    public static int AbsoluteBonus = 1;
    public static int RelativeBonus = 2;
    public static int Min = 3;
    public static int Max = 4;
}

public class StatType {
    public static int HealthMax = 0;
    public static int HealthRegen = 1;
    public static int Damage = 2;
    public static int Speed = 3;
    public static int Luck = 4;
    public static int CooldownReduction = 5;
}

public enum StatModifierType {
	HealthRatio,
	DurationRatio,
	Counter,
    Duration
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