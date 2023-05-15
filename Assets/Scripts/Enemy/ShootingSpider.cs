using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingSpider : Enemy, IDamageable
{
    private bool m_isShooting;
    [SerializeField] private float m_shootDelay = 0.5f;
    public GameObject bulletPrefab;
    [SerializeField] private float m_bulletForce;
    [SerializeField] private float m_firePointPadding;

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
        if (!m_isShooting)
        {
            StartCoroutine(ShootBullet());
        }
    }

    private IEnumerator ShootBullet()
    {
        m_isShooting = true;
        yield return new WaitForSeconds(m_shootDelay);

        float distance = Vector2.Distance((Vector2)transform.position, (Vector2)player.position);

        Vector2 direction = -((Vector2)transform.position - (Vector2)player.position).normalized;



        Vector3 firePoint = transform.position + (Vector3)direction * m_firePointPadding;

        // Calculate rotation to face the bullet towards direction of shot
        Quaternion bulletRotation = Quaternion.LookRotation(Vector3.forward, direction);

        // Adjust the rotation by 90 degrees if the sprite's "front" is facing right
        bulletRotation *= Quaternion.Euler(0, 0, 90);

        GameObject bulletInstance = Instantiate(bulletPrefab, firePoint, bulletRotation);
        bulletInstance.GetComponent<Rigidbody2D>().velocity = direction * m_bulletForce;

        m_isShooting = false;
    }
}
