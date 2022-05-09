using UnityEngine;

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
    }

}
