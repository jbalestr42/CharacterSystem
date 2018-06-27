using UnityEngine;
using UnityEngine.Assertions;

public class AttributeModifier<T> : IAttributeModifier where T : BaseAttributeParam {

    T _params;

    public virtual void OnStart(GameObject p_owner) { }

    public virtual void Update(GameObject p_owner) {
        Param.factor = GetFactor();
        if (Param.inverse) {
            Param.factor = 1f - Param.factor;
        }
        p_owner.GetComponent<AttributeManager>().SetAttributeParam(Param);
    }

    public virtual void OnEnd(GameObject p_owner) { }

    public virtual bool IsOver() {
        return false;
    }

    public virtual float GetFactor() {
        return 1f;
    }

    public void SetAttributeParam(BaseAttributeParam p_params) {
        T value = (T)p_params;
        Assert.IsNotNull(value); // TODO Add error message
        _params = value;
    }

    public int GetAttributeType() {
        return _params.attributeType;
    }

    public T Param {
        get { return _params; }
    }
}