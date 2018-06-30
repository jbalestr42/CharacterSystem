using UnityEngine;

public interface ISkillCooldownTracker {
    void UpdateCooldown(float p_progress, float p_duration);
    void OnEnd();
}