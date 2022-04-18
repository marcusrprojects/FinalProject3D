using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    
    //Called as an action to play the game
    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); //loads next scene in scene management queue
    }

    //Called as an action to exit the game
    public void ExitGame()
    {
        Debug.Log("Exit");
        Application.Quit();
    }

}
