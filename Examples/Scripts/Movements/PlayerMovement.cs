using UnityEngine;
using System.Collections;

public class PlayerMovement : AMovement {
	public override void UpdateMovement() {
		float x = Input.GetAxis("Horizontal") * Time.deltaTime * Speed.Value;
		float y = Input.GetAxis("Vertical") * Time.deltaTime *  Speed.Value;

        var newPosition = new Vector2(transform.position.x + x, transform.position.y + y);
        transform.GetComponent<Rigidbody2D>().MovePosition(newPosition);
	}
}