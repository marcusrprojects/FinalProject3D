using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class World5 : MonoBehaviour
{
    void Start()
    {
        DialogueManager.instance.Play("AI_5_1");

        /*
        if (!AudioManager.instance.IsPlaying("Tropical"))
        {
            AudioManager.instance.Play("Tropical");
        }
        */
    }

    public static void CorpEnd()
    {
        SceneManager.LoadScene("Ending_Corp");
    }

    public static void FreeEnd()
    {
        SceneManager.LoadScene("Ending_Free");
    }
}
