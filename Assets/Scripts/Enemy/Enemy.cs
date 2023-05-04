using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class Enemy : MonoBehaviour, IDamageable
{
    [SerializeField] protected int m_health;
    [SerializeField] protected float m_movementSpeed;
    [SerializeField] protected int m_damage;
    [SerializeField] private float m_updatePathInterval = 1f; // Time interval to update the path

    [SerializeField] protected NavMeshAgent m_agent;
    [SerializeField] protected Transform player;
    private float elapsedTime;


    protected virtual void Start()
    {
        m_agent = GetComponent<NavMeshAgent>();
        player = PlayerController.Instance.transform;
        m_agent.updateRotation = false;
        m_agent.updateUpAxis = false;
        m_agent.speed = m_movementSpeed;
    }

    protected virtual void Update()
    {
        
        elapsedTime += Time.deltaTime;
        
        if (elapsedTime >= m_updatePathInterval)
        {
            UpdatePath();
            elapsedTime = 0f;
        }
    }

    private void UpdatePath()
    {
        if (IsVisibleInCamera(Camera.main))
        {
            if (player != null && m_agent != null && m_agent.isOnNavMesh)
            {
                Vector3 targetPosition = player.position;
                targetPosition.z = transform.position.z; // Lock the Z position
                m_agent.SetDestination(targetPosition);
            }
        }
    }

    protected virtual void Move()
    {
        // Implement the enemy's movement logic here
    }

    protected virtual void Attack()
    {
        // Implement the enemy's attack logic here
    }

    public virtual void TakeDamage(int damage)
    {
        m_health -= damage;
        if (m_health <= 0)
        {
            Die();
        }
    }
    public bool IsVisibleInCamera(Camera camera)
    {
        Vector3 viewportPoint = camera.WorldToViewportPoint(transform.position);

        // Check if the viewport point is within the viewport bounds (0 to 1 for both x and y)
        return viewportPoint.x >= 0 && viewportPoint.x <= 1 && viewportPoint.y >= 0 && viewportPoint.y <= 1;
    }
    public virtual void Die()
    {
        // Implement the enemy's death behavior, e.g., play animation, drop loot, etc.
        Destroy(gameObject);
    }
}
