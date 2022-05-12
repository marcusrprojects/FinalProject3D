using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Word0 : MonoBehaviour
{
    public Transform teleportDest;
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        DialogueManager.instance.Play("AI_1_FIXED");

        if (!AudioManager.instance.IsPlaying("Tropical"))
        {
            AudioManager.instance.Play("Tropical");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /*private void OnTriggerEnter(Collider other)
    {
        //SceneManager.LoadScene(scenename);
        player.transform.position = teleportDest.transform.position;
    }*/

    public static void NextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); //loads next scene in scene management queue
    }
}
