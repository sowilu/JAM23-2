using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;

public enum Mutation
{
    Health,
    AI,
    BodyPart
}

public class Item : MonoBehaviour
{
    [EnumFlags]
    public Mutation mutation;
    
    
    [ShowIf("mutation", Mutation.Health)]
    [Header("Health")]
    public int maxHpBoost;
    [ShowIf("mutation", Mutation.Health)]
    public int hpBoost;
    
}
