using UnityEngine;
using UnityEngine.SceneManagement;

public class IntroOffice : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        DialogueManager.instance.Play("BOSS_1");
    }

    public static void Continue()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); //loads next scene in scene management queue
    }

}
