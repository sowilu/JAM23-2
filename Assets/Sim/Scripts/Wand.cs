using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wand : MonoBehaviour
{
    public AudioClip castSound;
    public Transform castPoint;
    
    public float coolDown = 0.5f;
    public float cooldownLeft = 0;

    public GameObject spellParticle;
    private bool canCast = true;

    private void Update()
    {
        cooldownLeft -= Time.deltaTime;
        
        if (cooldownLeft <= 0)
        {
            canCast = true;
        }
    }


    public void Cast()
    {
        if (canCast)
        {
            canCast = false;
            
            if(castSound != null)
                Audio.Play(castSound);
            Instantiate(spellParticle, castPoint.position, castPoint.rotation);
        }
    }


}
