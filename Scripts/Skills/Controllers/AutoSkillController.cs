using UnityEngine;
using UnityEngine.EventSystems;

public class AutoSkillController : ASkillController
{
    public override bool CanCast(GameObject p_owner)
    {
        return true;
    }
}