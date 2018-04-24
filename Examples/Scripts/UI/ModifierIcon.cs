using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModifierIcon : MonoBehaviour {

    UnityEngine.UI.Image _root;
    UnityEngine.UI.Image _overlay;
    UnityEngine.UI.Text _text;

    public void Init(Color p_color, bool p_showDuration) {
        _root = GetComponent<UnityEngine.UI.Image>();
        _overlay = transform.GetChild(0).GetComponent<UnityEngine.UI.Image>();
        _text = GetComponentInChildren<UnityEngine.UI.Text>();

        _root.color = p_color;
        _overlay.enabled = p_showDuration;
        _text.enabled = p_showDuration;
    }

    public void UpdateUI(float p_progress, float p_duration) {
        _text.text = p_duration.ToString("F1");
        _overlay.fillAmount = p_progress;
    }
}