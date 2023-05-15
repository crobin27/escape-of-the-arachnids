using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockScript : MonoBehaviour, IDamageable
{
    public void TakeDamage(int damage)
    {
        Die();
    }

    public void Die()
    {
        Destroy(gameObject);
    }
}
