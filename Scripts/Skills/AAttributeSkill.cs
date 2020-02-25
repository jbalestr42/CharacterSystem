using UnityEngine;

public abstract class AAttributeSkill : ASkill
{
    public Attribute<float> CastDurationAtt = null;
    public override float CastDuration { get { return CastDurationAtt == null ? 0f : CastDurationAtt.Value; } }

    public Attribute<float> CooldownDurationAtt = null;
    public override float CooldownDuration { get { return CooldownDurationAtt == null ? 0f : CooldownDurationAtt.Value; } }

    protected AAttributeSkill(GameObject p_owner, Attribute<float> p_castDuration, Attribute<float> p_cooldownDuration)
        :base(p_owner, 0f, 0f)
    {
        CastDurationAtt = p_castDuration;
        CooldownDurationAtt = p_cooldownDuration;
    }
}