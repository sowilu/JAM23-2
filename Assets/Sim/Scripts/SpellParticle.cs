using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class SpellParticle : MonoBehaviour
{
    public Sound bounce;
    public GameObject magicEffect;
    public GameObject bounceEffect;
    
    public float chanceOfSuccess = 0.6f;
    private int bounces = 0;
    public float speed = 10;
    public float ttl = 10;

    private Rigidbody rb;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.velocity = transform.forward * speed;

    }

    private void Update()
    {
        rb.velocity = rb.velocity.normalized * speed;
        
        ttl -= Time.deltaTime;
        if (ttl <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(bounce != null)
            Audio.Play(bounce);
        
        speed++;
        
        
        if(bounceEffect != null)
            Instantiate(bounceEffect, transform.position, transform.rotation);
        
        if (collision.transform.CompareTag("Enemy"))
        {
            //ensure that after one bounce off it will work next time
            if(Random.Range(0f, 1f) < chanceOfSuccess && bounces == 0 || bounces == 1)
            {
                //print(collision.gameObject.name);
                Mutator.inst.Mutate(collision.gameObject.GetComponent<Spell>());
                
                if(magicEffect != null)
                    Instantiate(magicEffect, transform.position, Quaternion.identity);
                
                Destroy(collision.gameObject);
                if(Player.inst != null)Player.inst.transform.position = collision.transform.position;
                
                Destroy(gameObject);
            }
            else
            {

                bounces++;
            }
        }
    }
}
