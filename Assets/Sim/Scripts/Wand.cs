using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wand : MonoBehaviour
{
    public AudioClip castSound;
    public Transform castPoint;
    
    public float coolDown = 0.5f;

    public GameObject spellParticle;
    private bool canCast = true;
    
    
    public void Cast()
    {
        if (canCast)
        {
            canCast = false;
            
            if(castSound != null)
                Audio.Play(castSound);
            Instantiate(spellParticle, castPoint.position, castPoint.rotation);

            StartCoroutine(CoolDown());
        }
    }
    
    IEnumerator CoolDown()
    {
        var timePassed = 0f;
        while (timePassed < coolDown)
        {
            yield return null;
            timePassed+=Time.deltaTime;
            
            GameplayUI.Instance.cooldownImage.fillAmount = timePassed / coolDown;
        }
        canCast = true;
    }


}
