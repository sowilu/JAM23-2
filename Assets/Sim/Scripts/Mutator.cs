using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Mutator : MonoBehaviour
{
    public UnityEvent<string> onMutate;
    
    public static Mutator inst;

    private void Awake()
    {
        if (inst == null)
        {
            inst = this;
        }
        else
        {
            Destroy(this);
        }
    }
    
    public void Mutate(Item item)
    {
        if (item == null) return;
        
        //TODO: check why item passes not null check but is still null here
        try
        {
            if (item.mutation == Mutation.Health)
            {
                Mutate(item.hpBoost, item.maxHpBoost);
            }
            else if (item.mutation == Mutation.AI)
            {
                
                Mutate(item.sleepinessBoost, item.hungerBoost, item.fearBoost, item.sleepRateBoost, item.hungerRateBoost, item.fearRateBoost, item.speedBoost);
            }
            else if(item.mutation == Mutation.BodyPart)
            {
                Mutate(item.bodyPartPrefab, item.bodyPartType);
            }
        }
        catch(Exception){}
    }

    public void Mutate(GameObject prefab, BodyPartType type)
    {
        var bodyPart = Pet.inst.bodyParts.Find(x => x.type == type);
        if (bodyPart.position.childCount > 0)
        {
            Destroy(bodyPart.position.GetChild(0).gameObject);
        }
        Instantiate(prefab, bodyPart.position).transform.localPosition = Vector3.zero;
        
        onMutate.Invoke($"Master, I have grown {prefab.name} on my {bodyPart.type}");
    }


    public void Mutate(float sleepinessBoost = 0, float hungerBoost = 0, float fearBoost = 0, float sleepRateBoost = 0,
        float hungerRateBoost = 0, float fearRateBoost = 0, float speedBoost = 0)
    {
        Pet.inst.brain.sleepiness += sleepinessBoost;
        Pet.inst.brain.hunger += hungerBoost;
        Pet.inst.brain.fear += fearBoost;
        Pet.inst.brain.sleepRate += sleepRateBoost;
        Pet.inst.brain.hungerRate += hungerRateBoost;
        Pet.inst.brain.fearRate += fearRateBoost;
        Pet.inst.brain.speed += speedBoost;
        
        var message = "Master, I am feeling ";
        if (sleepRateBoost > 0)
            message += "sleepy";
        if(hungerBoost > 0)
            message += " hungry";
        if(fearBoost > 0)
            message += " scared";
        
        if (sleepRateBoost > 0 || hungerRateBoost > 0 || fearRateBoost > 0 )
            message = "Master, I am getting more and more ";
        
        if (sleepRateBoost > 0)
            message += "sleepy";
        if(hungerRateBoost > 0)
            message += " hungry";
        if(fearRateBoost > 0)
            message += " scared";
        
        onMutate.Invoke(message);
    }

    public void Mutate(int hp = 0, int maxHp = 0)
    {
        Pet.inst.health.maxHp += maxHp;
        Pet.inst.health.HP += hp;

        var message = "Master, ";
        if (maxHp > 0)
            message += "I am feeling stronger";
        if(hp > 0)
            message += " I am feeling healthier";
        
        onMutate.Invoke(message);
    }
}
