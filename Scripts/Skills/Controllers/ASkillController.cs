using UnityEngine;

/// <summary>
/// Base class for skill controller
/// The purpose of this class is to have a generic way of managing the cooldown and requirements of a skill
/// </summary>
public abstract class ASkillController : MonoBehaviour
{
    protected enum SkillControllerState
    {
        None,
        WaitingCooldown,
        WaitingRequirements,
        Casting,
        Terminating,
    }

    public ASkill Skill { get; set; } = null;
    public IProgressTracker ProgressTracker { get; set; } = null;

    SkillControllerState _state = SkillControllerState.None;
    float _cooldownTimer = 0.0f;

    void Update()
    {
        switch (_state)
        {
            case SkillControllerState.None:
                if (Skill != null)
                {
                    SetState(SkillControllerState.WaitingCooldown);
                }
                break;

            case SkillControllerState.WaitingCooldown:
                _cooldownTimer = Mathf.Clamp(_cooldownTimer - Time.deltaTime, 0.0f, Skill.CooldownDuration);
                if (ProgressTracker != null)
                {
                    ProgressTracker.UpdateProgress(GetCooldownRatio(), _cooldownTimer);
                }

                if (_cooldownTimer <= 0.0f)
                {
                    SetState(SkillControllerState.WaitingRequirements);
                }
                break;

            case SkillControllerState.WaitingRequirements:
                if (Skill.AreRequirementsValidated() && CanCast(Skill.Owner))
                {
                    SetState(SkillControllerState.Casting);
                }

                break;

            case SkillControllerState.Casting:
                Debug.Log("Cast new spell: " + Skill.Name);
                Skill.OnCast(Skill.Owner);
                SetState(SkillControllerState.Terminating);
                break;

            case SkillControllerState.Terminating:
                if (Skill.IsDone)
                {
                    Terminate();
                    Skill.Reset();
                    SetState(SkillControllerState.WaitingCooldown);
                }
                break;

            default:
                break;
        }
    }
    
    void SetState(SkillControllerState p_state)
    {
        _state = p_state;
    }

    float GetCooldownRatio()
    {
        return _cooldownTimer / Skill.CooldownDuration;
    }

    public virtual void Terminate()
    {
        _cooldownTimer = Skill.CooldownDuration;
    }

    public abstract bool CanCast(GameObject p_owner);
}