using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class SpecialProjectile : MonoBehaviour
{
    public int damage = 30;
    public float speed = 15;
    public GameObject destructionEffects;
    
    Rigidbody rb;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    
    void Update()
    {
        //move forward
        rb.velocity = (transform.forward * 0.3f + Vector3.down) * speed;
    }

    private void OnTriggerEnter(Collider other)
    {
        //if tag is enemy add to targets
        if (other.CompareTag("Enemy"))
        {
            var health = other.GetComponent<Health>();

            if (health != null)
            {
                health.HP -= damage;
            }
        }
        
        //if there are effects spawn them
        if (destructionEffects != null)
        {
            Instantiate(destructionEffects, transform.position, transform.rotation);
        }
        
        //destroy projectile
        Destroy(gameObject);
    }
}
