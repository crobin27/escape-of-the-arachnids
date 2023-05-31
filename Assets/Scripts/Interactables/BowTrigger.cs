using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Player;
public class BowTrigger : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        PlayerController player = PlayerController.Instance;
        Shooting shootingComponent = player.GetComponent<Shooting>();
        if (shootingComponent != null)
        {
            shootingComponent.enabled = true; // This enables the Shooting component
        }
        Destroy(gameObject);
    }
}
