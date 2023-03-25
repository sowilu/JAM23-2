using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class SpellParticle : MonoBehaviour
{
    public GameObject magicEffect;
    
    public float chanceOfSuccess = 0.6f;
    private int bounces = 0;
    public float speed = 10;

    private Rigidbody rb;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.velocity = transform.forward * speed;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag("Enemy"))
        {
            //ensure that after one bounce off it will work next time
            if(Random.Range(0f, 1f) < chanceOfSuccess && bounces == 0 || bounces == 1)
            {
                Mutator.inst.Mutate(collision.gameObject.GetComponent<Spell>());
                
                if(magicEffect != null)
                    Instantiate(magicEffect, transform.position, Quaternion.identity);
                
                Destroy(gameObject);
            }
            else
            {
                bounces++;
            }
        }
    }
}