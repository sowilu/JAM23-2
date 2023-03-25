using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedAttack : AttackBase
{
    private List<Transform> targets = new();
    
    public TargetedProjectile projectile;
    
    public override void AttackAction()
    {
        Debug.Log("Ranged Attack");
        
        //remove null targets
        targets.RemoveAll(x => x == null);
        
        //find nearest enemy
        targets.Sort((a, b) => Vector3.Distance(transform.position, a.position).CompareTo(Vector3.Distance(transform.position, b.position)));
        
        Instantiate(projectile, transform.position, transform.rotation).target = targets[0];
    }

    private void OnTriggerEnter(Collider other)
    {
        //if tag is enemy add to targets
        if (other.CompareTag("Enemy"))
        {
            targets.Add(other.transform);
        }
    }
    
    private void OnTriggerExit(Collider other)
    {
        //if tag is enemy remove from targets
        if (other.CompareTag("Enemy"))
        {
            targets.Remove(other.transform);
        }
    }
}
