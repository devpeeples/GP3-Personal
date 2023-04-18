using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class MainMenuUI : MonoBehaviour
{
    public AudioSource source;

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

       // sourcePlay();
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
        //sourcePlay();
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
        sourcePlay();
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
        sourcePlay();
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
        sourcePlay();
        main.SetActive(false);
        credits.SetActive(false);
        controls.SetActive(true);
        settings.SetActive(false);
        keyboard.SetActive(true);
        controller.SetActive(false);
    }

    public void Controller()
    {
        sourcePlay();
        main.SetActive(false);
        credits.SetActive(false);
        controls.SetActive(true);
        settings.SetActive(false);
        keyboard.SetActive(false);
        controller.SetActive(true);
    }

    public void SeeCreditsMenu()
    {
        sourcePlay();
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
        sourcePlay();
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
        sourcePlay();
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
        sourcePlay();
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
    public void sourcePlay()
    {
        if (source != null)
        {
            source.Play();
        }

    }
}
