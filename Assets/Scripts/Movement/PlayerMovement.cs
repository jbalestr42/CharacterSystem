using UnityEngine;
using System.Collections;

public class PlayerMovement : Movement {
	public override void UpdateMovement() {
		float x = Input.GetAxis("Horizontal") * Time.deltaTime * Speed.Total;
		float y = Input.GetAxis("Vertical") * Time.deltaTime * Speed.Total;

		transform.Translate(x, y, 0);
	}
}