using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Duration : AttributeModifier {

    protected float _endOfEffect;

    public override void OnStart(GameObject p_owner) {
        _endOfEffect = Time.realtimeSinceStartup + Param.duration;
    }

    public override void Update(GameObject p_owner) {
        base.Update(p_owner);
        if (Param.modifierIcon != null) {
            Param.modifierIcon.UpdateCooldown(GetRatio(), _endOfEffect - Time.realtimeSinceStartup);
        }
    }

    public override void OnEnd(GameObject p_owner) {
        if (Param.modifierIcon != null) {
            Param.modifierIcon.OnEnd();
        }
    }

    public override bool IsOver() {
        return (_endOfEffect - Time.realtimeSinceStartup) <= 0.0f;
    }

    public float GetRatio() {
        return Mathf.Clamp((_endOfEffect - Time.realtimeSinceStartup) / Param.duration, 0.0f, 1.0f);
    }
}