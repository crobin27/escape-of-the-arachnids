using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EggSpawner : MonoBehaviour, IDamageable
{
    public GameObject spiderPrefab;
    public int numSpidersPerSpawn;
    public float spawnCooldown;
    private bool isSpawning = false;
    [SerializeField] private int m_health;

    public void TakeDamage(int damage)
    {
        m_health -= damage;
        if(m_health <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        Destroy(gameObject);
    }
    

    private void Update()
    {
        if (!isSpawning & IsVisibleInCamera(Camera.main))
        {
            StartCoroutine(SpawnSpiders());
        }
    }


    public bool IsVisibleInCamera(Camera camera)
    {
        Vector3 viewportPoint = camera.WorldToViewportPoint(transform.position);

        // Check if the viewport point is within the viewport bounds (0 to 1 for both x and y)
        return viewportPoint.x >= 0 && viewportPoint.x <= 1 && viewportPoint.y >= 0 && viewportPoint.y <= 1;
    }

    private IEnumerator SpawnSpiders()
    {
        isSpawning = true;
        for (int i = 0; i < numSpidersPerSpawn; i++)
        {
            yield return new WaitForSeconds(0.5f);
            Instantiate(spiderPrefab, transform.position + new Vector3(0.5f, 0.5f, 0), Quaternion.identity);
        }
        yield return new WaitForSeconds(spawnCooldown);
        isSpawning = false;
    }
}
