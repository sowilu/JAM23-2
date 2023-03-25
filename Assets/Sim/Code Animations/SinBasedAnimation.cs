using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SinBasedAnimation : MonoBehaviour
{
    public bool move = false;
    public bool rotate = true;
    
    public float speed;
    
    public Vector3 defaultRotation;

    public Vector3 mainDirection;

    public float angle = 90;

    private Vector3 startPos;

    private void Start()
    {
        startPos = transform.position;
    }

    void LateUpdate()
    {
        if (rotate)
        {
            var rotation = mainDirection * Mathf.Sin(Time.time * speed) * angle + defaultRotation;
                    
            transform.localRotation = Quaternion.Euler(rotation);
        }

        if (move)
        {
            transform.position = new Vector3(
                transform.position.x, 
                startPos.y + (mainDirection * Mathf.Sin(Time.time * speed) * angle).y,
                transform.position.z);
        }
    }
}
