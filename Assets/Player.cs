using System;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct BodyPart
{
   public BodyPartType type;
   public Transform position;
}

public class Player : MonoBehaviour
{
    public static Player inst;
    
    public Movement movement;
    public Health health;
    
    public List<BodyPart> bodyParts;
   
    private void Awake()
    {
        inst = this;
    }
    
    private void Start()
    {
        Inputs.onMove.AddListener(movement.Move);
    }
}
