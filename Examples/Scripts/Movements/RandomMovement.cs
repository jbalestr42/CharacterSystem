using UnityEngine;
using System.Collections;

public class RandomMovement : AMovement {
    Vector2 _direction;

	public override void Init(Attribute<float> p_speed) {
		base.Init(p_speed);
		StartCoroutine(ChangeDirection());
    }

	public override void UpdateMovement() {
        var newPosition = _direction * Time.deltaTime * Speed.Value;
        transform.GetComponent<Rigidbody2D>().MovePosition(new Vector2(transform.position.x + newPosition.x, transform.position.y + newPosition.y));
    }

    IEnumerator ChangeDirection() {
        while (gameObject != null && gameObject.activeInHierarchy) {
            yield return new WaitForSeconds(1f);
            _direction = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f));
            _direction.Normalize();
        }
    }

    void OnCollisionEnter2D(Collision2D p_collision2D) {
        if (p_collision2D.gameObject.tag == "Wall") {
            _direction = new Vector2(transform.position.x, transform.position.y) - p_collision2D.contacts[0].point;
            _direction.Normalize();
        }
    }
}