using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool GamePaused = false;

    public GameObject pauseMenu;
    void Update()
    {
        if (Input.GetButtonDown("Pause")) // the "Tab" key and "joystick button 7" in the Input Manager.
        {
            if (GamePaused)
            {
                Resume();
            }
            else
            {
                Pause();   
            }
        }
    }

    public void Resume ()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        GamePaused = false;
    }

    void Pause ()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        GamePaused = true;
    }

    public void GoToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
        GamePaused = false;
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Quit");
    }
}
