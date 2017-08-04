using UnityEngine;
using System.Collections;

public interface IKillable
{
    void GetDamage(GameObject p_owner);
    bool IsDead();
    void Die();
}