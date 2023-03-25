using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

public enum Mutation
{
    Health,
    AI,
    BodyPart
}

public enum BodyPartType
{
    Head,
    Body,
    Legs,
    Tail
}

public class Spell : MonoBehaviour
{
    public float chanceOfSuccess = 0.6f;
    private int bounces = 0;
    
    [EnumFlags]
    public Mutation mutation;
    
    public string description;
    
    [ShowIf("mutation", Mutation.Health)]
    [Header("Health")]
    public int maxHpBoost;
    [ShowIf("mutation", Mutation.Health)]
    public int hpBoost;
    
    
    [FormerlySerializedAs("bodyPart")]
    [ShowIf("mutation", Mutation.BodyPart)]
    [Header("Body Part")]
    public BodyPartType bodyPartType;
    [ShowIf("mutation", Mutation.BodyPart)]
    public GameObject bodyPartPrefab;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag("Enemy"))
        {
            //ensure that after one bounce off it will work next time
            if(Random.Range(0f, 1f) < chanceOfSuccess && bounces == 0 || bounces == 1)
            {
                Mutator.inst.Mutate(this);
                Destroy(gameObject);
                bounces = 0;
            }
            else
            {
                bounces++;
            }
        }
    }
}
