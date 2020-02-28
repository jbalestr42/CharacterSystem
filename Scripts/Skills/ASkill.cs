using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Base class to create a skill
/// A skill controller must controls a skill
/// To reset the skill, the flag IsDone must be set to true when the skill is finished
/// </summary>
public abstract class ASkill
{
    public virtual string Name { get; private set; } = null;
    public virtual float CooldownDuration { get; protected set; }
    public GameObject Owner { get; private set; } = null;
    public List<IRequirement> Requirements { get; protected set; } = new List<IRequirement>();
    public bool IsDone { get; protected set; }

    public ASkill(string p_name, GameObject p_owner, float p_cooldownDuration)
    {
        Name = p_name;
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

    public virtual void Reset()
    {
        IsDone = false;
    }

    public virtual void OnCast(GameObject p_owner)
    {
        Cast(p_owner);
        IsDone = true;
    }

    protected abstract void Cast(GameObject p_owner);
}