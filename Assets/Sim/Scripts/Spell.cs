using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

public enum Mutation
{
    Endurance,
    Agility,
    Attack
}

public enum BodyPartType
{
    Head,
    Hands,
    Body,
    Legs,
    Tail
}

public class Spell : MonoBehaviour
{
    [Header("Body Part")]
    public BodyPartType bodyPartType;
    public GameObject bodyPartPrefab;
    
    [EnumFlags]
    public Mutation mutation;

    [ShowIf("mutation", Mutation.Endurance)]
    [Header("Health")]
    public int maxHpBoost;
    [ShowIf("mutation", Mutation.Endurance)]
    public int hpBoost;
    
    [FormerlySerializedAs("speed")]
    [ShowIf("mutation", Mutation.Agility)]
    [Header("Speed")]
    public float speedBoost;

    [ShowIf("mutation", Mutation.Attack)] 
    [Header("Attacks")]
    public float spellCooldownBoost;
    [ShowIf("mutation", Mutation.Attack)] 
    public float meleeCooldownBoost;
    [ShowIf("mutation", Mutation.Attack)] 
    public float rangeCooldownBoost;
    [ShowIf("mutation", Mutation.Attack)] 
    public float specialCooldownBoost;
    
    
    public string description;
}
