using UnityEngine.Audio;
using UnityEngine;

//Made using this tutorial: https://www.youtube.com/watch?v=6OT43pvUyfY

[System.Serializable]
public class Sound
{
    public string name;
    
    public AudioClip clip;

    [Range(0f, 1f)]
    public float volume = 1;

    [Range(1f, 12f)]
    public float pitch = 1;

    public bool loop;

    [HideInInspector]
    public AudioSource source;

}
