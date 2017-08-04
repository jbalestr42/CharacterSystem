﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ASkill : MonoBehaviour {

	List<ARequirement> _requirements;

	Character _owner;

	float _castTimer = 0.0f;
	float _castDuration = 0.0f;

	float _cooldownDuration = 0.0f;
	float _cooldown = 0.0f;

	void Awake() {
		_owner = GetComponent<Character>();
	}

	protected void Init(float p_castDuration, float p_cooldownDuration, List<ARequirement> p_requirements) {
		_castDuration = p_castDuration;
		_cooldownDuration = p_cooldownDuration;
		_requirements = p_requirements;
	}

	// TODO update cast bar
	// prevent owner to move when casting
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
		}
	}

	void OnGUI() {
		GUI.Label(new Rect(10, 10, 500, 20), "Skill : ");
		GUI.Label(new Rect(10, 150, 500, 20), "Remaining cooldown " + _cooldown.ToString());
		GUI.Label(new Rect(10, 170, 500, 20), "Casting Time " + _castTimer.ToString() + "/" + _castDuration.ToString());
	}

	bool IsRequirementValidated() {
		foreach (ARequirement requirement in _requirements) {
			if (!requirement.IsValid(_owner)) {
				return false;
			}
		}
		return true;
	}

	public abstract void Cast(Character p_owner);
}


/*
public class DirectionalBullet : ASkill {

	// prefab
	public Bullet _bullet; // Mouffy
	Vector3 _direction;

	public override void Cast(GameObject p_owner) {
		Bullet bullet = Instantiate(_bullet);
		_direction = (p_owner.GetMousePosition() - p_owner.transform.position).Normalize();
	}

	void Update() {
		if (_target != null) {
			_bullet.transform.position += _direction * Time.deltaTime;
		}
	}
}


public class Silence : ASkill {

	public override void Cast(GameObject p_owner) {
		// déclenche l'effet visuel
		p_owner.GetTarget().AddDebuff(new SilenceBuff());
	}
}*/