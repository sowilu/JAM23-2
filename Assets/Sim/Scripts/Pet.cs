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
public class Pet : MonoBehaviour
{
   public static Pet inst;

   public Health health;

   public List<BodyPart> bodyParts;
   
   private void Awake()
   {
      inst = this;
   }
}
