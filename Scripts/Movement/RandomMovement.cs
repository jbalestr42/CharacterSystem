using UnityEngine;
using System.Collections;

public class RandomMovement : Movement
{
    Vector2 m_direction;

	public override void Init(Stat p_speed)
    {
		base.Init(p_speed);
		StartCoroutine(ChangeDirection());
    }

	public override void UpdateMovement()
    {
        transform.Translate(m_direction * Time.deltaTime * Speed.Total);
    }

    IEnumerator ChangeDirection()
    {
        while (gameObject != null && gameObject.activeInHierarchy)
        {
            yield return new WaitForSeconds(1f);
            m_direction = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f));
            m_direction.Normalize();
        }
    }
}