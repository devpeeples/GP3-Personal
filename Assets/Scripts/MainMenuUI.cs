using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class MainMenuUI : MonoBehaviour
{
    public GameObject main;
    public GameObject credits;
    public GameObject settings;
    public GameObject controls;
    public GameObject keyboard;
    public GameObject controller;

    public GameObject mainFirstButton; 
    public GameObject controlsFirstButton; 
    public GameObject controlsClosedButton;
    public GameObject creditsFirstButton;
    public GameObject creditsClosedButton;
    public GameObject settingsFirstButton;
    public GameObject settingsClosedButton;

    private void Awake()
    {
        main.SetActive(true);
        credits.SetActive(false);
        controls.SetActive(false);
        settings.SetActive(false);
        keyboard.SetActive(false);
        controller.SetActive(false);

        //clear selected object
        EventSystem.current.SetSelectedGameObject(null);
        //set a new selected object
        EventSystem.current.SetSelectedGameObject(mainFirstButton);
    }

    private void Start()
    {
        main.SetActive(true);
        credits.SetActive(false);
        controls.SetActive(false);
        settings.SetActive(false);
        keyboard.SetActive(false);
        controller.SetActive(false);

        Time.timeScale = 1f;

        //clear selected object
        EventSystem.current.SetSelectedGameObject(null);
        //set a new selected object
        EventSystem.current.SetSelectedGameObject(mainFirstButton);
    }

    public void PlayGame()
    {
        SceneManager.LoadScene("Tutorial");
    }

    public void SeeControlsMenu()
    {
        main.SetActive(false);
        credits.SetActive(false);
        controls.SetActive(true);
        settings.SetActive(false);
        keyboard.SetActive(true);
        controller.SetActive(false);

        //clear selected object
        EventSystem.current.SetSelectedGameObject(null);
        //set a new selected object
        EventSystem.current.SetSelectedGameObject(controlsFirstButton);
    }
    
     public void CloseControlsMenu()
    {
        main.SetActive(true);
        credits.SetActive(false);
        controls.SetActive(false);
        settings.SetActive(false);
        keyboard.SetActive(false);
        controller.SetActive(false);

        //clear selected object
        EventSystem.current.SetSelectedGameObject(null);
        //set a new selected object
        EventSystem.current.SetSelectedGameObject(controlsClosedButton);
    }
    public void Keyboard()
    {
        main.SetActive(false);
        credits.SetActive(false);
        controls.SetActive(true);
        settings.SetActive(false);
        keyboard.SetActive(true);
        controller.SetActive(false);
    }

    public void Controller()
    {
        main.SetActive(false);
        credits.SetActive(false);
        controls.SetActive(true);
        settings.SetActive(false);
        keyboard.SetActive(false);
        controller.SetActive(true);
    }

    public void SeeCreditsMenu()
    {
        main.SetActive(false);
        credits.SetActive(true);
        controls.SetActive(false);
        settings.SetActive(false);
        keyboard.SetActive(false);
        controller.SetActive(false);

        //clear selected object
        EventSystem.current.SetSelectedGameObject(null);
        //set a new selected object
        EventSystem.current.SetSelectedGameObject(creditsFirstButton);
    }

    public void CloseCreditsMenu()
    {
        main.SetActive(true);
        credits.SetActive(false);
        controls.SetActive(false);
        settings.SetActive(false);
        keyboard.SetActive(false);
        controller.SetActive(false);

        //clear selected object
        EventSystem.current.SetSelectedGameObject(null);
        //set a new selected object
        EventSystem.current.SetSelectedGameObject(creditsClosedButton);
    }

    public void SeeSettingsMenu()
    {
        main.SetActive(false);
        credits.SetActive(false);
        controls.SetActive(false);
        settings.SetActive(true);
        keyboard.SetActive(false);
        controller.SetActive(false);

        //clear selected object
        EventSystem.current.SetSelectedGameObject(null);
        //set a new selected object
        EventSystem.current.SetSelectedGameObject(settingsFirstButton);
    }

    public void CloseSettingsMenu()
    {
        main.SetActive(true);
        credits.SetActive(false);
        controls.SetActive(false);
        settings.SetActive(false);
        keyboard.SetActive(false);
        controller.SetActive(false);

        //clear selected object
        EventSystem.current.SetSelectedGameObject(null);
        //set a new selected object
        EventSystem.current.SetSelectedGameObject(settingsClosedButton);
    }

    public void QuitGame()
    {
        Debug.Log("Quit Successful!");
        Application.Quit();
    }
}
