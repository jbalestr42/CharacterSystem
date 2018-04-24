public class AttributeValueType {
    public static int Default = -1;
    public static int Base = 0;
    public static int AbsoluteBonus = 1;
    public static int RelativeBonus = 2;
    public static int Min = 3;
    public static int Max = 4;
    public static int Add = 5;
}

public class AttributeType {
    public static int HealthMax = 0;
    public static int HealthRegen = 1;
    public static int Damage = 2;
    public static int Speed = 3;
    public static int Luck = 4;
    public static int CooldownReduction = 5;
    public static int CanUseSkill = 6;
    public static int Health = 7;
}

public enum AttributModifierType {
    Regen,
	DurationRatio,
	Counter,
    Duration,
    Copy
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