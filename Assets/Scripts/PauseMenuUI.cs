using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class PauseMenuUI : MonoBehaviour
{
    public static bool GamePaused = false;

    public GameObject pauseMenu; 
    public GameObject controlsMenu;
    public GameObject settingsMenu;
    public GameObject keyboard;
    public GameObject controller;

    public GameObject pauseFirstButton; 
    public GameObject controlsFirstButton;
    public GameObject controlsCloseButton; 
    public GameObject settingsFirstButton; 
    public GameObject settingsCloseButton;

    void Update()
    {
        if (Input.GetButtonDown("Pause")) // the "Tab" key and "joystick button 7" in the Input Manager.
        {
            if (GamePaused)
            {
                Debug.Log("Game paused");
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
        controlsMenu.SetActive(false);
        settingsMenu.SetActive(false);
        Time.timeScale = 1f;
        GamePaused = false;
    }

    void Pause ()
    {
        pauseMenu.SetActive(true);
        Debug.Log("pause menu should be active");
        controlsMenu.SetActive(false);
        settingsMenu.SetActive(false);
        Time.timeScale = 0f;
        GamePaused = true;
    }

    public void SeeControls()
    {
        pauseMenu.SetActive(false);
        controlsMenu.SetActive(true);
        settingsMenu.SetActive(false);
        Time.timeScale = 0f;
        GamePaused = true;

        //clear selected object
        EventSystem.current.SetSelectedGameObject(null);
        //set a new selected object
        EventSystem.current.SetSelectedGameObject(controlsFirstButton);
    }
    public void CloseControls()
    {
        pauseMenu.SetActive(true);
        controlsMenu.SetActive(false);
        settingsMenu.SetActive(false);
        Time.timeScale = 0f;
        GamePaused = true;

        //clear selected object
        EventSystem.current.SetSelectedGameObject(null);
        //set a new selected object
        EventSystem.current.SetSelectedGameObject(controlsCloseButton);
    }

    public void Keyboard()
    {
        pauseMenu.SetActive(false);
        controlsMenu.SetActive(true);
        settingsMenu.SetActive(false);
        Time.timeScale = 0f;
        GamePaused = true;

        keyboard.SetActive(true);
        controller.SetActive(false);
    }

    public void Controller()
    {
        pauseMenu.SetActive(false);
        controlsMenu.SetActive(true);
        settingsMenu.SetActive(false);
        Time.timeScale = 0f;
        GamePaused = true;

        keyboard.SetActive(false);
        controller.SetActive(true);
    }

    public void SeeSettings()
    {
        pauseMenu.SetActive(false);
        controlsMenu.SetActive(false);
        settingsMenu.SetActive(true);
        Time.timeScale = 0f;
        GamePaused = true;

        //clear selected object
        EventSystem.current.SetSelectedGameObject(null);
        //set a new selected object
        EventSystem.current.SetSelectedGameObject(settingsFirstButton);
    }

    public void CloseSettings()
    {
        pauseMenu.SetActive(true);
        controlsMenu.SetActive(false);
        settingsMenu.SetActive(false);
        Time.timeScale = 0f;
        GamePaused = true;

        //clear selected object
        EventSystem.current.SetSelectedGameObject(null);
        //set a new selected object
        EventSystem.current.SetSelectedGameObject(settingsCloseButton);
    }

    public void GoToHub()
    {
        SceneManager.LoadScene("PHub");
        GamePaused = false;
    }
    public void GoToMainMenu()
    {
        SceneManager.LoadScene("MainMenuV2");
        GamePaused = false;
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Quit");
    }
}
