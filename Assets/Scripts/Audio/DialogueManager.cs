using System;
using System.Collections;
using UnityEngine;

public class DialogueManager : MonoBehaviour
{
    public Sound[] quotes;

    public static DialogueManager instance;

    private float volume = 1; //global volume parameter set by the player

    private Sound current;

    //Awake is called before Start
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);

        foreach (Sound s in quotes)
        {
            s.source = gameObject.AddComponent<AudioSource>();

            s.source.clip = s.clip;

            s.source.volume = s.volume * volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
        }
    }

    public void Play(string name)
    {
        Sound s = Array.Find(quotes, sound => sound.name == name);
        if (s == null)
        {
            Debug.LogWarning("Quote: " + name + " not found!");
            return;
        }
        if(current != null)
        {
            current.source.Stop();
        }
        current = s;
        current.source.Play();
    }

    public void Stop()
    {
        if (current != null)
        {
            current.source.Stop();
        }
    }

    public void RunCoroutine(IEnumerator coroutine)
    {
        StartCoroutine(coroutine);
    }

    public bool IsPlaying()
    {
        return current != null && current.source.isPlaying;
    }

    public void UpdateVolume(float newVolume)
    {
        foreach (Sound s in quotes)
        {
            s.source.volume = s.volume * newVolume;
        }
        volume = newVolume;
    }
}
