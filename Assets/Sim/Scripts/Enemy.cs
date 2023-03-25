using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class Enemy : MonoBehaviour
{
    public int damage = 5;
    public float speed = 5;
    public Transform target;
    public float cooldown = 3;
    
    public Health health;
    public NavMeshAgent agent;
    bool canAttack = true;

    private void Awake()
    {
        health = GetComponent<Health>();
        agent = GetComponent<NavMeshAgent>();
    }

    void Start()
    {
        agent.speed = speed;
        agent.stoppingDistance = 1;
    }

    private void Update()
    {
        if(target != null)
        {
            agent.SetDestination(target.position);
        
            //if player at stopping distance
            if (agent.remainingDistance <= agent.stoppingDistance && canAttack)
            {
                //attack
                Player.inst.health.HP -= damage;

                canAttack = false;
                Invoke(nameof(CooledDown), cooldown);
            }
        }
    }
    
    void CooledDown()
    {
        canAttack = true;
    }
    
 
}
