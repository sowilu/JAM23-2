using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeAttack : AttackBase
{
    public bool swing;
    public GameObject swingEffect;
    
    bool inMotion;
    public override void AttackAction()
    {
        if (!swing) return;
        
        inMotion = true;
        
        if(swingEffect != null) swingEffect.SetActive(true);
        Debug.Log("Melee Attack");
    }
    
    private void Update()
    {
        if (inMotion)
        {
            //rotate from -90 to 90
            var rotation = transform.localRotation.eulerAngles;
            rotation.z = Mathf.Lerp(-90, 90, Time.deltaTime);
            
            
            //when rotation is 90, stop and reset rotation to 0
            if (rotation.z >= 90)
            {
                rotation.z = 0;
                inMotion = false;
                if(swingEffect != null) swingEffect.SetActive(false);
            }
            
            transform.rotation = Quaternion.Euler(rotation);
        }
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
