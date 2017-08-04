using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ASkill : MonoBehaviour {

	List<ARequirement> _requirements;

	float _castTimer;
	float _castDuration;

	float _cooldownDuration;
	float _cooldown;

	public abstract void Cast(Character p_owner);

	// TODO update cast bar
	// prevent owner to move when casting
	void Update(Character p_owner) {
		if (_cooldown <= 0.0f) {
			if (IsRequirementValidated(p_owner)) {
				_castTimer -= Time.deltaTime;
					if (_castTimer <= 0.0f) {
						Cast(p_owner);
						_castTimer = _castDuration;
					}
						_cooldown = _cooldownDuration;
			} else {
				_castTimer = _castDuration;
			}
		} else {
			_cooldown -= Time.deltaTime;
		}
	}

	bool IsRequirementValidated(Character p_owner) {
		foreach (ARequirement requirement in _requirements) {
			if (!requirement.IsValid(p_owner)) {
				return false;
			}
		}
		return true;
	}
}

/*
// Exemple
// Dans ce cas la bullet peut etre un object qui s'update lui même (à voir selon les besoins)
public class HomingBullet : ASkill {

	// prefab
	public Bullet _bullet; // Mouffy AHAHA
	GameObject _target;

	public override void Cast(GameObject p_owner) {
		Bullet bullet = Instantiate(_bullet);
		_target = p_owner.GetTarget()
	}

	void Update() {
		if (_target != null) {
			Vector3 direction = (_target.transform.position - transform.position).Normalize();
			_bullet.transform.position += direction * Time.deltaTime;
		}
	}
}

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