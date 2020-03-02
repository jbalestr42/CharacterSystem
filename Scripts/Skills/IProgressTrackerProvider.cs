using UnityEngine;

public interface IProgressTrackerProvider<T>
{
    GameObject CreateTracker(T p_trackerData);
}