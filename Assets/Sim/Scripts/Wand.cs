using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wand : MonoBehaviour
{
    public Transform castPoint;
    
    public float coolDown = 0.5f;

    public GameObject spellParticle;
    private bool canCast = true;
    
    
    public void Cast()
    {
        if (canCast)
        {
            canCast = false;
            
            Instantiate(spellParticle, castPoint.position, castPoint.rotation);
            
            Invoke(nameof(CooledDown), coolDown);
        }
    }

    void CooledDown()
    {
        canCast = true;
    }
}
