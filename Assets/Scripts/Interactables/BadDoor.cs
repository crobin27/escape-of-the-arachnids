using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BadDoor : MonoBehaviour
{
    public DoorLevelManager mgr;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            mgr.BackToStart();
        }
    }
}
