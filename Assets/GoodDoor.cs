using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoodDoor : MonoBehaviour
{
    public DoorLevelManager mgr;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        mgr.GoForward();
    }
}
