using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    //On Menu Start
    private void Start()
    {

        AudioManager.instance.Play("Main Menu");

    }

    //Called as an action to play the game
    public void PlayGame()
    {
        //AudioManager.instance.RunCoroutine(AudioTransition());
        //AudioManager.instance.Stop("Main Menu");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); //loads next scene in scene management queue
    }

    //Called as an action to exit the game
    public void ExitGame()
    {
        Debug.Log("Exit");
        Application.Quit();
    }

    //Transition between menu and level
    private IEnumerator AudioTransition()
    {
        //AudioManager.instance.ReverseSound("Main Menu");
        //Debug.Log("Reverse 1");
        //yield return new WaitForSeconds(5f);
        AudioManager.instance.Stop("Main Menu");
        Debug.Log("Stop");
        AudioManager.instance.ReverseSound("Main Menu");
        Debug.Log("Reverse 2");
        AudioManager.instance.Play("Spaceport Intro");
        Debug.Log("Intro");
        while (AudioManager.instance.IsPlaying("Spaceport Intro"))
        {
            yield return null;
        }
        AudioManager.instance.Play("Spaceport Loop");
        Debug.Log("Loop");
    }

}
