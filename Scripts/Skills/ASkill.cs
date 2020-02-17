using System.Collections.Generic;
using UnityEngine;

public abstract class ASkill : MonoBehaviour
{
    // TODO Can be a list in case of multiple item want the cooldown ?
    IProgressTracker _progressTracker = null;

    List<IRequirement> _requirements;

    float _castTimer = 0.0f;
    float _castDuration = 0.0f;

    float _cooldownDuration = 0.0f;
    float _cooldown = 0.0f;

    protected void Init(float p_castDuration, float p_cooldownDuration, List<IRequirement> p_requirements, IProgressTracker p_progressTracker)
    {
        _castDuration = p_castDuration;
        _cooldownDuration = p_cooldownDuration;
        _requirements = p_requirements;
        _progressTracker = p_progressTracker;
    }

    // TODO update cast bar
    // prevent owner to cast multiple skills here ? or may be not our problem here ?
    void Update()
    {
        if (_cooldown <= 0.0f)
        {
            if (IsRequirementValidated())
            {
                _castTimer -= Time.deltaTime;
                if (_castTimer <= 0.0f)
                {
                    Debug.Log("Cast new spell");
                    Cast(gameObject);
                    _castTimer = _castDuration;
                    _cooldown = _cooldownDuration;
                }
            }
            else
            {
                _castTimer = _castDuration;
            }
        }
        else
        {
            _cooldown = Mathf.Clamp(_cooldown - Time.deltaTime, 0.0f, _cooldownDuration);
            if (_progressTracker != null)
            {
                _progressTracker.UpdateProgress(GetCooldownRatio(), _cooldown);
            }
        }
    }

    bool IsRequirementValidated()
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
        return _cooldown / _cooldownDuration;
    }

    public abstract void Cast(GameObject p_owner);
}