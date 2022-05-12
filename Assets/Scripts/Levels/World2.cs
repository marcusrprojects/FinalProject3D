using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class World2 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        DialogueManager.instance.Play("AI_2_1");

        //if (!AudioManager.instance.IsPlaying("Tropical"))
        //{
            //AudioManager.instance.Play("Tropical");
        //}
    }

    public static void NextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); //loads next scene in scene management queue
    }
}
