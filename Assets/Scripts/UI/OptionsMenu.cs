using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionsMenu : MonoBehaviour
{
    
    //Called as an action: changes the volume of the game
    public void ChangeVolume(float volume)
    {
        AudioManager.instance.UpdateVolume(volume);
    }

}
