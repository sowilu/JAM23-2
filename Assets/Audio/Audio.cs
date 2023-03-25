using UnityEngine;

public class Audio : UnitySingleton<Audio>
{
    private AudioSource source;

    private void Awake()
    {
        if(!source)source = gameObject.AddComponent<AudioSource>();
    }
    
    
    
    public static void Play(AudioClip clip, float pitch = 1f)
    {
        if (clip == null) return;
        if (Instance == null) return;
        
        Instance.source.pitch = pitch;
        Instance.source.PlayOneShot(clip);
    }


    public static void Play(Sound sound)
    {
        var pitch = Random.Range(sound.pitch.x, sound.pitch.y);
        Play(sound.clip,pitch);
    }
}
