using System.Collections.Generic;
using UnityEngine;

public abstract class AAttributeSkill : ASkill
{
    Attribute<float> _castDuration = null;
    public override float CastDuration { get { return _castDuration == null ? 0f : _castDuration.Value; } }

    Attribute<float> _cooldownDuration = null;
    public override float CooldownDuration { get { return _cooldownDuration == null ? 0f : _cooldownDuration.Value; } }

    protected void Init(Attribute<float> p_castDuration, Attribute<float> p_cooldownDuration, List<IRequirement> p_requirements, IProgressTracker p_progressTracker)
    {
        _castDuration = p_castDuration;
        _cooldownDuration = p_cooldownDuration;

        base.Init(CastDuration, CooldownDuration, p_requirements, p_progressTracker);
    }
}