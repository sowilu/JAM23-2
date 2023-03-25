using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : UnitySingleton<CameraShake>
{
    public float shakeDuration = 0.5f;
    public float shakeAmount = 0.1f;

    private Vector3 originalPosition;
    private float currentShakeDuration = 0f;

    private void Awake()
    {
        originalPosition = transform.localPosition;
    }

    private void Update()
    {
        if (currentShakeDuration > 0)
        {
            // Generate random offset for camera position
            Vector3 randomOffset = Random.insideUnitCircle * shakeAmount;

            // Apply the offset to the camera's position
            transform.localPosition = originalPosition + randomOffset;

            // Decrease shake duration over time
            currentShakeDuration -= Time.deltaTime;
        }
        else
        {
            // Reset camera position to original position
            transform.localPosition = originalPosition;
        }
    }

    public void ShakeCamera()
    {
        // Start a new camera shake if one isn't already in progress
        if (currentShakeDuration <= 0)
        {
            currentShakeDuration = shakeDuration;
        }
    }
}
