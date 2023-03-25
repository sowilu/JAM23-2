using System;
using UnityEngine;

public class Swing : MonoBehaviour
{
    public Vector3 angle;
    public float interval = 1;


    private void Update()
    {
        transform.localRotation = Quaternion.Euler(angle * Mathf.Sin(Time.time * interval * 6.28f));
    }
}
