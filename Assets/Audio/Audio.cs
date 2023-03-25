using UnityEngine;

public class Audio : UnitySingleton<Audio>
{
    private AudioSource source;

    private void Awake()
    {
        if(!source)source = gameObject.AddComponent<AudioSource>();
    }
    
    
    
    public static void Play(AudioClip clip)
    {
        if (clip == null) return;
        if (Instance == null) return;
        
        Instance.source.PlayOneShot(clip);
    }


    public static void Play(Sound sound)
    {
        Play(sound.clip);
    }
}
