using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class PauseMenuUI : MonoBehaviour
{
    public AudioSource source;

    public GameObject playerShellShooter;
    public bool GamePaused = false;
    //public bool e; 
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
    private bool shootingOn; 

    void Update()
    {
        if (Input.GetButtonDown("Pause")) // the "Tab" key and "joystick button 7" in the Input Manager.
        {
            
            if (GamePaused)
            {
                Debug.Log("game was not paused, so now it resumes with tab");
                Resume();
            }
            else
            {
                Debug.Log("game pausing from tab");
                Pause();   
            }
            
            //GamePaused = true; 
        }
        /*
        if(GamePaused == true)
        {
            Pause();
        }
        */
    }

    public void Resume ()
    {
        sourcePlay();
        GamePaused = false;
        pauseMenu.SetActive(false);
        controlsMenu.SetActive(false);
        settingsMenu.SetActive(false);
        
        Time.timeScale = 1f;
        if (!shootingOn)
        {
            playerShellShooter.GetComponent<RBPlayerShooting>().enabled = true;
        }
        else if (shootingOn)
        {
            playerShellShooter.GetComponent<PlayerShooting2>().enabled = true;
        }

    }

    void Pause ()
    {
        pauseMenu.SetActive(true);
        Debug.Log("pause menu should be active");
        controlsMenu.SetActive(false);
        settingsMenu.SetActive(false);
        Time.timeScale = 0f;
        if (playerShellShooter.GetComponent<RBPlayerShooting>().enabled)
        {
            shootingOn = false;
            playerShellShooter.GetComponent<RBPlayerShooting>().enabled = false;
        }
        else if (playerShellShooter.GetComponent<PlayerShooting2>().enabled)
        {
            shootingOn = true;
            playerShellShooter.GetComponent<PlayerShooting2>().enabled = false;
        }
        GamePaused = true;
    }

    public void SeeControls()
    {
        sourcePlay();
        pauseMenu.SetActive(false);
        controlsMenu.SetActive(true);
        settingsMenu.SetActive(false);
        Time.timeScale = 0f;
        GamePaused = true;

        //clear selected object
        EventSystem.current.SetSelectedGameObject(null);
        //set a new selected object
        EventSystem.current.SetSelectedGameObject(controlsFirstButton);
        if (playerShellShooter.GetComponent<RBPlayerShooting>().enabled)
        {
            shootingOn = false;
            playerShellShooter.GetComponent<RBPlayerShooting>().enabled = false;
        }
        else if (playerShellShooter.GetComponent<PlayerShooting2>().enabled)
        {
            shootingOn = true;
            playerShellShooter.GetComponent<PlayerShooting2>().enabled = false;
        }
    }
    public void CloseControls()
    {
        sourcePlay();
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
        sourcePlay();
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
        sourcePlay();
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
        sourcePlay();
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
        sourcePlay();
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
        sourcePlay();
        SceneManager.LoadScene("PHub");
        GamePaused = false;
    }
    public void GoToMainMenu()
    {
        sourcePlay();
        SceneManager.LoadScene("MainMenuV2");
        GamePaused = false;
    }

    public void QuitGame()
    {
        GamePaused = false;
        Application.Quit();
        Debug.Log("Quit");
    }
    public void sourcePlay()
    {
        if(source != null)
        {
            source.Play();
        }
       
    }
}
