using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class World5 : MonoBehaviour
{
    void Start()
    {
        DialogueManager.instance.Play("AI_2_1");

        if (!AudioManager.instance.IsPlaying("Tropical"))
        {
            AudioManager.instance.Play("Tropical");
        }
    }

    public static void CorpEnd()
    {
        Application.Quit();
    }

    public static void FreeEnd()
    {
        Application.Quit();
    }
}
