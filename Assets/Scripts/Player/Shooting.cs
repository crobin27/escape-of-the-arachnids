using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player
{
    public class Shooting : MonoBehaviour
    {
        [SerializeField] private GameObject bulletPrefab;
        [SerializeField] private float bulletSpeed = 10f;
        [SerializeField] private TouchManager touchMgr;
        [SerializeField] private float shootingDelay = 0.5f;
        [SerializeField] private float spawnDistance = 1.75f;
        private bool m_isShooting;
        private Animator m_animator;

        private void Awake()
        {
            m_animator = GetComponent<Animator>();
        }
        private void Update()
        {
            if (!m_isShooting && touchMgr.IsTapping)
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

            // Calculate rotation to face the bullet towards direction of shot
            Quaternion bulletRotation = Quaternion.LookRotation(Vector3.forward, direction);

            // Adjust the rotation by 90 degrees to align sprite with the direction
            bulletRotation *= Quaternion.Euler(0, 0, 90);

            // Instantiate the bullet
            GameObject bullet = Instantiate(bulletPrefab, spawnPosition, bulletRotation);
            Rigidbody2D bulletRigidbody = bullet.GetComponent<Rigidbody2D>();

            // Set the bullet's velocity
            bulletRigidbody.velocity = direction * bulletSpeed;
            m_animator.SetFloat("ShootX", direction.x);
            m_animator.SetFloat("ShootY", direction.y);
            m_animator.SetTrigger("Shoot");

            // Wait for the shooting delay
            yield return new WaitForSeconds(shootingDelay);

            m_isShooting = false;
        }
    }
}