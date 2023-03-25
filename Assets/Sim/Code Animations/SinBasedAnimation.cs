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
    void Update()
    {
        if (rotate)
        {
            var rotation = mainDirection * Mathf.Sin(Time.time * speed) * angle + defaultRotation;
                    
            transform.localRotation = Quaternion.Euler(rotation);
        }

        if (move)
        {
            transform.position += mainDirection * Mathf.Sin(Time.time * speed) * angle;
        }
    }
}
