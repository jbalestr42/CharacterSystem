using System.Collections.Generic;
using UnityEngine;

public abstract class ASkill : MonoBehaviour
{
    IProgressTracker _progressTracker = null;
    List<IRequirement> _requirements = null;

    float _castTimer = 0.0f;
    public virtual float CastDuration { get; protected set; }

    float _cooldownTimer = 0.0f;
    public virtual float CooldownDuration { get; protected set; }

    protected void Init(float p_castDuration, float p_cooldownDuration, List<IRequirement> p_requirements, IProgressTracker p_progressTracker)
    {
        CastDuration = p_castDuration;
        CooldownDuration = p_cooldownDuration;
        _requirements = p_requirements;
        _progressTracker = p_progressTracker;
    }

    // The ASkill could use the attribute manager to use a cooldown modifier attribute, casting time modifier attribute, IsCasting attribute, CanCast attribute, etc.
    void Update()
    {
        if (_cooldownTimer <= 0.0f)
        {
            if (AreRequirementsValidated())
            {
                _castTimer -= Time.deltaTime;
                if (_castTimer <= 0.0f)
                {
                    Debug.Log("Cast new spell");
                    Cast(gameObject);
                    _castTimer = CastDuration;
                    _cooldownTimer = CooldownDuration;
                }
            }
            else
            {
                _castTimer = CastDuration;
            }
        }
        else
        {
            _cooldownTimer = Mathf.Clamp(_cooldownTimer - Time.deltaTime, 0.0f, CooldownDuration);
            if (_progressTracker != null)
            {
                _progressTracker.UpdateProgress(GetCooldownRatio(), _cooldownTimer);
            }
        }
    }

    bool AreRequirementsValidated()
    {
        if (_requirements != null)
        {
            foreach (var requirement in _requirements)
            {
                if (!requirement.IsValid(gameObject))
                {
                    return false;
                }
            }
        }
        return true;
    }

    float GetCooldownRatio()
    {
        return _cooldownTimer / CooldownDuration;
    }

    public abstract void Cast(GameObject p_owner);
}