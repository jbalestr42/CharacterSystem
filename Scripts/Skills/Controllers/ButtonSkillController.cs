using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonSkillController : ASkillController, IPointerDownHandler, IPointerUpHandler
{
    bool _canCast = false;

    public override bool CanCast(GameObject p_owner)
    {
        return _canCast;
    }
    
    public void OnPointerDown(PointerEventData eventData)
    {
        _canCast = true;
    }
    
    public void OnPointerUp(PointerEventData eventData)
    {
        _canCast = false;
    }
}