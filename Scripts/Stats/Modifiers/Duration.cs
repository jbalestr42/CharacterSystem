using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Duration : AStatModifier {

    protected float _endOfEffect;

    public override void OnStart(GameObject p_owner) {
        _endOfEffect = Time.realtimeSinceStartup + Attribute.duration;
    }

    public override bool IsOver() {
        return (_endOfEffect - Time.realtimeSinceStartup) <= 0.0f;
    }

    public override float GetFactor(GameObject p_owner) {
        return 1f;
    }

    public float GetRatio() {
        return (_endOfEffect - Time.realtimeSinceStartup) / Attribute.duration;
    }
}