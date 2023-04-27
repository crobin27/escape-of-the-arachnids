using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class Enemy : MonoBehaviour, IDamageable
{
    [SerializeField] protected int health;
    [SerializeField] protected float movementSpeed;
    [SerializeField] protected int damage;
    [SerializeField] private float updatePathInterval = 1f; // Time interval to update the path

    [SerializeField] protected NavMeshAgent agent;
    [SerializeField] protected Transform player;
    private float elapsedTime;


    protected virtual void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
        agent.speed = movementSpeed;
    }

    protected virtual void Update()
    {
        elapsedTime += Time.deltaTime;

        if (elapsedTime >= updatePathInterval)
        {
            UpdatePath();
            elapsedTime = 0f;
        }
    }

    private void UpdatePath()
    {
        if (player != null && agent != null && agent.isOnNavMesh)
        {
            Vector3 targetPosition = player.position;
            targetPosition.z = transform.position.z; // Lock the Z position
            agent.SetDestination(targetPosition);
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
        health -= damage;
        if (health <= 0)
        {
            Die();
        }
    }

    public virtual void Die()
    {
        // Implement the enemy's death behavior, e.g., play animation, drop loot, etc.
        Destroy(gameObject);
    }
}
