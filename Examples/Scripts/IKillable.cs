using UnityEngine;
using System.Collections;

public interface IKillable
{
	void GetDamage(GameObject p_owner, float p_damage);
    bool IsDead();
    void Die();
}