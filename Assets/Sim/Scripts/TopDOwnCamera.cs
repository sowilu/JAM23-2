using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopDOwnCamera : MonoBehaviour
{
    public Transform player;
    public float smoothTime = 0.3f;
    public Vector3 cameraOffset;

    private Vector3 velocity = Vector3.zero;

    void LateUpdate()
    {
        Vector3 targetPosition = player.position + cameraOffset;
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
    }
}
