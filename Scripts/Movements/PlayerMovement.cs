using UnityEngine;
using System.Collections;

public class PlayerMovement : AMovement {
	public override void UpdateMovement() {
		float x = Input.GetAxis("Horizontal") * Time.deltaTime * Speed.Value;
		float y = Input.GetAxis("Vertical") * Time.deltaTime * Speed.Value;

		transform.Translate(x, y, 0);
	}
}