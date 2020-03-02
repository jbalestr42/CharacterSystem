using UnityEngine;

public interface ISkillGroup<T>
{
    GameObject CreateSkill(T p_trackerData);
}