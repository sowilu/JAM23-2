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
