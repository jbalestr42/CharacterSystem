using UnityEngine;

public interface ISkillCooldownUpdater {
    void UpdateCooldown(float p_progress, float p_duration);
}