using UnityEngine;
using System.Collections;

public abstract class AMovement : MonoBehaviour {

    Attribute<float> _speed;

	void LateUpdate() {
		UpdateMovement();
	}

	public Attribute<float> Speed {
		get { return _speed; }
	}

	public virtual void Init(Attribute<float> p_speed) {
		_speed = p_speed;
	}

	public abstract void UpdateMovement();

	public static AMovement AddMovement(GameObject p_character, MovementType p_movementType) {
		switch (p_movementType) {
		case MovementType.Player:
			return p_character.AddComponent<PlayerMovement>();

		case MovementType.Random:
			return p_character.AddComponent<RandomMovement>();

		default:
			Debug.Log("The enum " + p_movementType.ToString() + " is not recognized.");
			break;
		}
		return null;
	}
}