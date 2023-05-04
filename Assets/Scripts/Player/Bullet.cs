using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private int m_bulletDamage = 1;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        IDamageable hit = collision.gameObject.GetComponent<IDamageable>();
        if (hit != null)
        {
            hit.TakeDamage(m_bulletDamage);
        }
        Destroy(gameObject);
    }
}
