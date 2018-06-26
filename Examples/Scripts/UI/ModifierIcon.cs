using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModifierIcon : MonoBehaviour, ISkillCooldownUpdater {

    UnityEngine.UI.Image _root;
    UnityEngine.UI.Image _overlay;
    UnityEngine.UI.Text _text;

    bool _showDuration = true;

    public void Init(Color p_color, bool p_showDuration) {
        _root = GetComponent<UnityEngine.UI.Image>();
        _overlay = transform.GetChild(0).GetComponent<UnityEngine.UI.Image>();
        _text = GetComponentInChildren<UnityEngine.UI.Text>();

        _root.color = p_color;
        _showDuration = p_showDuration;
        EnableTimer(p_showDuration);
    }

    public void UpdateCooldown(float p_progress, float p_duration) {
        _text.text = p_duration.ToString("F1");
        _overlay.fillAmount = p_progress;
        if (p_progress <= 0f) {
            EnableTimer(false);
        } else {
            EnableTimer(true);
        }
    }

    public void OnEnd() {
        Destroy(gameObject);
    }

    public void EnableTimer(bool p_enable) {
        if (_showDuration) {
            _overlay.enabled = p_enable;
            _text.enabled = p_enable;
        }
    }
}