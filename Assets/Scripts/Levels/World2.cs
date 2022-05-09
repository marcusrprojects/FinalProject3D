using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class World2 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        DialogueManager.instance.Play("AI_2_1");

        if (!AudioManager.instance.IsPlaying("Tropical"))
        {
            AudioManager.instance.Play("Tropical");
        }
    }
}
