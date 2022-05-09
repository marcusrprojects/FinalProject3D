using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioTrigger : MonoBehaviour
{
    public static void TriggerAudio(string name)
    {
        AudioManager.instance.Play(name);
    }

    public static void TriggerDialogue(string name)
    {
        DialogueManager.instance.Play(name);
    }
}
