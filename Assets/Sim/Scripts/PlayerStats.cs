using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct BodyPart
{
   public BodyPartType type;
   public Transform position;
}
public class PlayerStats : MonoBehaviour
{
   public static PlayerStats inst;

   public Health health;

   public List<BodyPart> bodyParts;
   
   private void Awake()
   {
      inst = this;
   }
}
