using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pet : MonoBehaviour
{
   public static Pet inst;

   public Health health;
   private void Awake()
   {
      inst = this;
   }
}
