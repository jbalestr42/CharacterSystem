using System.Collections.Generic;
using UnityEngine;

public abstract class ASkill
{
    public virtual float CastDuration { get; protected set; }
    public virtual float CooldownDuration { get; protected set; }
    public GameObject Owner { get; private set; } = null;
    public List<IRequirement> Requirements { get; protected set; } = new List<IRequirement>();

    public ASkill(GameObject p_owner, float p_castDuration, float p_cooldownDuration)
    {
        CastDuration = p_castDuration;
        CooldownDuration = p_cooldownDuration;
        Owner = p_owner;
    }

    public virtual bool AreRequirementsValidated()
    {
        if (Requirements != null)
        {
            foreach (IRequirement requirement in Requirements)
            {
                if (!requirement.IsValid(Owner))
                {
                    return false;
                }
            }
        }
        return true;
    }

    public abstract void Cast(GameObject p_owner);

    // TODO isSkillTerminated to reset the colldown
}