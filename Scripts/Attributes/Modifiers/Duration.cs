﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Duration : AttributeModifier {

    protected float _endOfEffect;

    public override void OnStart(GameObject p_owner) {
        _endOfEffect = Time.realtimeSinceStartup + Attributes.duration;
    }

    public override void Update(GameObject p_owner) {
        p_owner.GetComponent<AttributeManager>().SetAttribute(Attributes);
    }

    public override bool IsOver() {
        return (_endOfEffect - Time.realtimeSinceStartup) <= 0.0f;
    }

    public float GetRatio() {
        return Mathf.Clamp((_endOfEffect - Time.realtimeSinceStartup) / Attributes.duration, 0.0f, 1.0f);
    }
}