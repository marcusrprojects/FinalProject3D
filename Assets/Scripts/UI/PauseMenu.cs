using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    //Called as an action to continue the game
    public void ContinueGame()
    {
        Time.timeScale = 1;
        Cursor.lockState = CursorLockMode.Locked;
    }

    //Called as an action to exit the game
    public void ExitGame()
    {
        Debug.Log("Exit");
        Application.Quit();
    }
}
