using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeAttack : AttackBase
{
    public override void AttackAction()
    {
        Debug.Log("Melee Attack");
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag("Enemy"))
        {
            var health = collision.transform.GetComponent<Health>();

            if (health != null)
            {
                health.HP -= damage;
            }
                
        }
    }
}
