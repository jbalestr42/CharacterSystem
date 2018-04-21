using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ADurationEffect : IEffect {

    float _duration;

    public ADurationEffect(float p_duration) {
        _duration = p_duration;
    }

    public void Update(GameObject _target) {
        _duration -= Time.deltaTime;
        UpdateEffect(_target, _duration);
    }

    public virtual bool IsOver() {
        return _duration <= 0.0f;
    }

    public abstract void OnStart(GameObject p_target);
    public abstract void OnEnd(GameObject p_target);
    protected abstract void UpdateEffect(GameObject p_target, float p_duration);
}