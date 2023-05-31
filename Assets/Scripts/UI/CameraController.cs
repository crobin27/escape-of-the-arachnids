using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    // distance fro camera to player
    private Vector3 offset = new Vector3(0, 0, -10);
    private float smoothSpeed = 0.125f;
    private Vector3 velocity = Vector3.zero;
    public Transform playerTransform;
    // private void Update()
    // {
    //     if (playerTransform)
    //     {
    //         transform.position = new Vector3(playerTransform.position.x, playerTransform.position.y, transform.position.z);
    //     }
    // }

    private void Update()
    {
        Vector3 targetPosition = playerTransform.position + offset;
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothSpeed);
    }
}
