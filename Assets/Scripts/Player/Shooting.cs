using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private float bulletSpeed = 10f;
    [SerializeField] private TouchManager touchMgr;
    [SerializeField] private float shootingDelay = 0.5f;
    [SerializeField] private float spawnDistance = 1.75f;

    private bool m_isShooting;

    private void Update()
    {
        if (touchMgr.IsTapping && !m_isShooting)
        {
            StartCoroutine(ShootWithDelay(touchMgr.TapLocation));
        }
    }

    private IEnumerator ShootWithDelay(Vector2 tapPosition)
    {
        m_isShooting = true;

        // Calculate the direction of the tap location
        Vector2 direction = (tapPosition - (Vector2)transform.position).normalized;

        // Calculate the spawn position near the player
        Vector3 spawnPosition = transform.position + (Vector3)direction * spawnDistance;
        spawnPosition.z = 0;

        // Instantiate the bullet
        GameObject bullet = Instantiate(bulletPrefab, spawnPosition, Quaternion.identity);
        bullet.transform.SetParent(transform);
        Rigidbody2D bulletRigidbody = bullet.GetComponent<Rigidbody2D>();

        // Set the bullet's velocity
        bulletRigidbody.velocity = direction * bulletSpeed;

        // Wait for the shooting delay
        yield return new WaitForSeconds(shootingDelay);

        m_isShooting = false;
    }
}
