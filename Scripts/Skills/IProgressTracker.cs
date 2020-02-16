using UnityEngine;

public interface IProgressTracker {
    void UpdateProgress(float p_progress, float p_duration);
    void OnEnd();
}