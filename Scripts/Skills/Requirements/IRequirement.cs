using UnityEngine;

public interface IRequirement
{
    bool IsValid(GameObject p_owner);
}