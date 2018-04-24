using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModifierIconGroup : MonoBehaviour {

    public GameObject _modifierUI;

	void Start () {
		
	}

    public ModifierIcon Add(Color p_color, bool p_showText) {
       var modifierUI =  Instantiate(_modifierUI);
        modifierUI.transform.SetParent(transform);
        modifierUI.GetComponent<ModifierIcon>().Init(p_color, p_showText);
        return modifierUI.GetComponent<ModifierIcon>();
    }
}
