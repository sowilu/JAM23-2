using UnityEngine;

public class Wand : MonoBehaviour
{
    public AudioClip castSound;
    public Transform castPoint;
    
    public float coolDown = 0.5f;
    public float cooldownLeft = 0;

    public GameObject spellParticle;

    private void Update()
    {
        cooldownLeft -= Time.deltaTime;
    }


    public void Cast()
    {
        if (!enabled) return;
        
        if (cooldownLeft <= 0)
        {
            cooldownLeft = coolDown;
            
            if(castSound != null)
                Audio.Play(castSound);
            Instantiate(spellParticle, castPoint.position, castPoint.rotation);
        }
    }


}
