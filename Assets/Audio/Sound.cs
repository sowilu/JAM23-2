using System.Collections;
using System.Collections.Generic;
using NaughtyAttributes;
using UnityEngine;

[ CreateAssetMenu ( fileName = "New Sound" , menuName = "Sound" ) ]
public class Sound : ScriptableObject
{
    public AudioClip clip;


    
    
    [Button()]
    public void Play()
    {
         Audio.Play(this);
    }
}
