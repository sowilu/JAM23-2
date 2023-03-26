using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class Enemy : MonoBehaviour
{
    public static bool disableAll = false;
    public int damage = 5;
    public float speed = 5;
    public Transform target;
    public float cooldown = 3;
    
    public Health health;
    public NavMeshAgent agent;
    bool canAttack = true;

    private void Awake()
    {
        disableAll = false;
        health = GetComponent<Health>();
        agent = GetComponent<NavMeshAgent>();
    }

    void Start()
    {
        agent.speed = speed;
        agent.stoppingDistance = 3;
    }

    private void Update()
    {
        if (disableAll)
        {
            gameObject.SetActive(false);
            target = null;
        }
        
        if(gameObject.activeSelf && target != null)
        {
            agent.SetDestination(target.position);
        
            //if player at stopping distance
            if (Vector3.Distance(transform.position, target.position) <= agent.stoppingDistance && canAttack)
            {
                //attack
                Player.inst.health.HP -= damage;
                
                if(Player.inst.health.HP <= 0)
                {
                    target = null;
                }

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
