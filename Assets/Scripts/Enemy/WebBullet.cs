using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WebBullet : MonoBehaviour
{
    [SerializeField] private int m_bulletDamage;
    [SerializeField] private float characterSlowdown;
    [SerializeField] private float enemySpeedup;
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerController.Instance.Speed = PlayerController.Instance.NormalSpeed * characterSlowdown;
        }
        else if (collision.gameObject.CompareTag("Enemy"))
        {
            Enemy enemy = collision.gameObject.GetComponent<Enemy>();
            enemy.Speed = enemy.NormalSpeed * enemySpeedup;
        }
        
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerController.Instance.Speed = PlayerController.Instance.NormalSpeed;
        }
        else if (collision.gameObject.CompareTag("Enemy"))
        {
            Enemy enemy = collision.gameObject.GetComponent<Enemy>();
            enemy.Speed = enemy.NormalSpeed;
        }
    }
}
