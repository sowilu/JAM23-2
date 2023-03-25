using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

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
    
    [FormerlySerializedAs("meleeAttackBase")] [HideInInspector]
    public MelleeAttack meleeAttack;
    [FormerlySerializedAs("rangeAttackBase")] [HideInInspector]
    public RangedAttack rangeAttack;
    [FormerlySerializedAs("specialAttackBase")] [HideInInspector]
    public SpecialAttack specialAttack;
   
    private void Awake()
    {
        inst = this;
    }
    
    private void Start()
    {
        Inputs.onMove.AddListener(movement.Move);
    }
}
