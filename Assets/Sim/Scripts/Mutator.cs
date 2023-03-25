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
            //Destroy(bodyPart.position.GetChild(0).gameObject);
            bodyPart.position.GetChild(0).gameObject.SetActive(false);
        }
        Instantiate(prefab, bodyPart.position).transform.localPosition = Vector3.zero;
        
        onMutate.Invoke($"Master, I have grown {prefab.name} on my {bodyPart.type}");
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
