using UnityEngine;

public class SoundPlayer : MonoBehaviour
{
    public Sound sound;
    public AudioClip clip;
    
    private void Start()
    {
        if(sound)Audio.Play(sound);
        if(clip)Audio.Play(clip);
    }
}
