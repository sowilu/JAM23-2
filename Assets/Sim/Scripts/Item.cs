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
    
    public string description;
    
    [ShowIf("mutation", Mutation.Health)]
    [Header("Health")]
    public int maxHpBoost;
    [ShowIf("mutation", Mutation.Health)]
    public int hpBoost;
    
   
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
