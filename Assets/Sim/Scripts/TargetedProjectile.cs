using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetedProjectile : MonoBehaviour
{
    public float speed = 15;
    
    public Transform target;
    
    void Update()
    {
        //rotate towards target, move towards target
        transform.LookAt(target);
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }
}
