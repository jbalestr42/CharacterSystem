using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ASkill : MonoBehaviour {

    ModifierIcon _icon;

	List<IRequirement> _requirements;

	Character _owner;

	float _castTimer = 0.0f;
	float _castDuration = 0.0f;

	float _cooldownDuration = 0.0f;
	float _cooldown = 0.0f;

	void Awake() {
		_owner = GetComponent<Character>();
        _icon = _owner._skillGroup.Add(Color.cyan, true);
	}

	protected void Init(float p_castDuration, float p_cooldownDuration, List<IRequirement> p_requirements) {
		_castDuration = p_castDuration;
		_cooldownDuration = p_cooldownDuration;
		_requirements = p_requirements;
	}

	// TODO update cast bar
	// prevent owner to cast multiple skills 
	void Update() {
		if (_cooldown <= 0.0f) {
			if (IsRequirementValidated()) {
				_castTimer -= Time.deltaTime;
				if (_castTimer <= 0.0f) {
					Debug.Log("Cast new spell");
					Cast(_owner);
					_castTimer = _castDuration;
					_cooldown = _cooldownDuration;
				}
			} else {
				_castTimer = _castDuration;
			}
		} else {
			_cooldown = Mathf.Clamp(_cooldown - Time.deltaTime, 0.0f, _cooldownDuration);
            _icon.UpdateUI(GetCooldownRatio(), _cooldown);
		}
	}

	bool IsRequirementValidated() {
        if (_requirements != null) {
            foreach (var requirement in _requirements) {
                if (!requirement.IsValid(gameObject)) {
                    return false;
                }
            }
        }
		return true;
	}

    float GetCooldownRatio() {
        return _cooldown / _cooldownDuration;
    }

    public Character Owner {
        get { return _owner; }
    }

	public abstract void Cast(Character p_owner);
}