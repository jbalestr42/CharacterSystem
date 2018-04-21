using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Stat : AAttribute {

    public Stat(float p_value, float p_min, float p_max)
        :base() {
        SetValue(StatValueType.Base, p_value);
        SetValue(StatValueType.AbsoluteBonus, 0f);
        SetValue(StatValueType.RelativeBonus, 0f);
        SetValue(StatValueType.Min, p_min);
        SetValue(StatValueType.Max, p_max);
        ComputeTotal();
    }
    
    public override void Reset() {
        SetValue(StatValueType.RelativeBonus, 0f);
        SetValue(StatValueType.AbsoluteBonus, 0f);
    }

    public override float ComputeTotal() {
        float total = (GetValue(StatValueType.Base) + GetValue(StatValueType.AbsoluteBonus)) * (1f + GetValue(StatValueType.RelativeBonus));
        return Mathf.Clamp(total, GetValue(StatValueType.Min), GetValue(StatValueType.Max));
    }
}