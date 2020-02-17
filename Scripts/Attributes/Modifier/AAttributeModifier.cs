using UnityEngine;
using UnityEngine.Assertions;

public abstract class AAttributeModifier<T, U> : IAttributeModifier where T : BaseAttributeParam where U : AAttribute
{
    T _params;

    public virtual void OnStart(GameObject p_owner) { }

    public void ApplyModifier(GameObject p_owner, AAttribute p_attribute)
    {
        //TODOD assert
        U attribute = (U)p_attribute;
        Assert.IsNotNull(attribute);
        ApplyModifierCast(p_owner, attribute);
    }

    // Todo rename
    public abstract void ApplyModifierCast(GameObject p_owner, U p_attribute);

    public virtual void OnEnd(GameObject p_owner) { }

    public virtual bool IsOver()
    {
        return false;
    }

    public void SetAttributeParam(BaseAttributeParam p_params)
    {
        T value = (T)p_params;
        Assert.IsNotNull(value); // TODO Add error message and better assert like is child class ...
        _params = value;
    }

    public int GetAttributeType()
    {
        return _params.attributeType;
    }

    public T Param
    {
        get { return _params; }
    }
}