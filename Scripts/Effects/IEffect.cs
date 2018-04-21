using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IEffect {
    
	void OnStart(GameObject p_target);
	void Update(GameObject p_target);
	void OnEnd(GameObject p_target);
    bool IsOver();
}