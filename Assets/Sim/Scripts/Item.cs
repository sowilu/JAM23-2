using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;
using UnityEngine.Serialization;

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

public class Item : MonoBehaviour
{
    [EnumFlags]
    public Mutation mutation;
    
    public string description;
    
    [ShowIf("mutation", Mutation.Health)]
    [Header("Health")]
    public int maxHpBoost;
    [ShowIf("mutation", Mutation.Health)]
    public int hpBoost;
    
    [ShowIf("mutation", Mutation.AI)]
    [Header("AI")]
    [MinMaxSlider(1,50)]public Vector2 sleepDurationBoost;
    [ShowIf("mutation", Mutation.AI)]
    [MinMaxSlider(1,50)]public Vector2 idleDurationBoost;
    [ShowIf("mutation", Mutation.AI)]
    [MinMaxSlider(1,50)]public Vector2 escapeDurationBoost;
    
    [ShowIf("mutation", Mutation.AI)]
    [Range(0,1)]public float sleepinessBoost = 0;
    [ShowIf("mutation", Mutation.AI)]
    [Range(0,1)]public float hungerBoost = 0;
    [ShowIf("mutation", Mutation.AI)]
    [Range(0,1)]public float fearBoost = 0;
    [ShowIf("mutation", Mutation.AI)]
    public float sleepRateBoost;
    [ShowIf("mutation", Mutation.AI)]
    public float hungerRateBoost;
    [ShowIf("mutation", Mutation.AI)]
    public float fearRateBoost;
    [ShowIf("mutation", Mutation.AI)]
    public float speedBoost;
    
    [FormerlySerializedAs("bodyPart")]
    [ShowIf("mutation", Mutation.BodyPart)]
    [Header("Body Part")]
    public BodyPartType bodyPartType;
    [ShowIf("mutation", Mutation.BodyPart)]
    public GameObject bodyPartPrefab;
   
    private void OnTriggerEnter(Collider other)
    { 
        //if items has parent return
        if (transform.parent != null)
        {
            ItemUI.inst.TurnOffPopup();
            return;
        }
        
        //if colliding wih player, display popup
        if (other.CompareTag("Player"))
        {
            ItemUI.inst.DisplayItem(this);
        }
    }
    
    
    private void OnTriggerExit(Collider other)
    {
        //if player leaves trigger, turn off popup
        if (other.CompareTag("Player"))
        {
            ItemUI.inst.TurnOffPopup();
        }
    }
}
