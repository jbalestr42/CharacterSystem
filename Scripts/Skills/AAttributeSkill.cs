using UnityEngine;

public abstract class AAttributeSkill : ASkill
{
    public Attribute<float> CooldownDurationAtt = null;
    public override float CooldownDuration { get { return CooldownDurationAtt == null ? 0f : CooldownDurationAtt.Value; } }

    protected AAttributeSkill(string p_name, GameObject p_owner, Attribute<float> p_cooldownDuration)
        :base(p_name, p_owner, 0f)
    {
        CooldownDurationAtt = p_cooldownDuration;
    }
}