using UnityEngine;

public abstract class ASkillController : MonoBehaviour
{
    public ASkill Skill { get; set; } = null;
    public IProgressTracker ProgressTracker { get; set; } = null;

    float _castTimer = 0.0f; // TODO remove castTimer
    float _cooldownTimer = 0.0f;

    void Update()
    {
        if (Skill != null)
        {
            if (_cooldownTimer <= 0.0f)
            {
                if (Skill.AreRequirementsValidated() && CanCast(Skill.Owner))
                {
                    _castTimer -= Time.deltaTime;
                    if (_castTimer <= 0.0f)
                    {
                        Debug.Log("Cast new spell");
                        Skill.Cast(Skill.Owner);
                        AfterSkillCast();
                    }
                }
                else
                {
                    _castTimer = Skill.CastDuration;
                }
            }
            else
            {
                _cooldownTimer = Mathf.Clamp(_cooldownTimer - Time.deltaTime, 0.0f, Skill.CooldownDuration);
                if (ProgressTracker != null)
                {
                    ProgressTracker.UpdateProgress(GetCooldownRatio(), _cooldownTimer);
                }
            }
        }
    }

    float GetCooldownRatio()
    {
        return _cooldownTimer / Skill.CooldownDuration;
    }

    public virtual void AfterSkillCast()
    {
        _castTimer = Skill.CastDuration;
        _cooldownTimer = Skill.CooldownDuration;
    }

    public abstract bool CanCast(GameObject p_owner);
}