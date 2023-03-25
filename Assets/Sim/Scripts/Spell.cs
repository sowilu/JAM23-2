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

    
}
