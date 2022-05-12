using UnityEngine;
using UnityEngine.SceneManagement;

public class World1 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        DialogueManager.instance.Play("AI_1_1");

        if (!AudioManager.instance.IsPlaying("Tropical"))
        {
            AudioManager.instance.Play("Tropical");
        }

        if (AudioManager.instance.IsPlaying("Spaceport Intro"))
        {
            AudioManager.instance.Stop("Spaceport Intro");
        }
        else if (AudioManager.instance.IsPlaying("Spaceport Loop"))
        {
            AudioManager.instance.Stop("Spaceport Loop");
        }
    }

    public static void NextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); //loads next scene in scene management queue
    }

}
