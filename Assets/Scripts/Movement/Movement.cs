using UnityEngine;
using System.Collections;

public abstract class Movement : MonoBehaviour {

	Stat m_speed;

	void Update() {
		UpdateMovement();
	}

	public Stat Speed {
		get { return m_speed; }
	}

	public virtual void Init(Stat p_speed) {
		m_speed = p_speed;
	}

	public abstract void UpdateMovement();

	public static Movement AddMovement(GameObject p_character, MovementType p_movementType) {
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