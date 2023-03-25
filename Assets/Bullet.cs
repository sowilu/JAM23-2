using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Bullet : MonoBehaviour
{
    public float ttl = 2f;
    public int damage = 10;
    public bool dieOnCollision = true;

    void Update()
    {
        if (ttl > 0) ttl -= Time.deltaTime;
        if (ttl < 0) Die();
    }

    void Die()
    {
        transform.DetachChildren();
        Destroy(gameObject);
    }

    private void OnTriggerEnter( Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            var enemy = other.gameObject.GetComponent<Enemy>();
            enemy.health.HP -= damage;
        }


        if (dieOnCollision) Die();
    }
}