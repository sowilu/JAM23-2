using NaughtyAttributes;
using UnityEngine;

[ CreateAssetMenu ( fileName = "New Sound" , menuName = "Sound" ) ]
public class Sound : ScriptableObject
{
    public AudioClip clip;

    [MinMaxSlider(0.5f,2f)] public Vector2 pitch = Vector2.one;
    
    
    [Button()]
    public void Play()
    {
         Audio.Play(this);
    }
}
