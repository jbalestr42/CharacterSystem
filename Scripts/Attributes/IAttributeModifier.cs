using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IAttributeModifier {

    void OnStart(GameObject p_owner);
    void Update(GameObject p_owner);
    void OnEnd(GameObject p_owner);
    bool IsOver();
    float GetFactor();
    void SetAttributeParam(BaseAttributeParam p_params);
    int GetAttributeType();
}