using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject main;
    public GameObject credits;
    public GameObject settings;
    public GameObject controls;
    public GameObject keyboard;
    public GameObject controller;

    private void Awake()
    {
        main.SetActive(true);
        credits.SetActive(false);
        controls.SetActive(false);
        settings.SetActive(false);
        keyboard.SetActive(false);
        controller.SetActive(false);
    }

    private void Start()
    {
        main.SetActive(true);
        credits.SetActive(false);
        controls.SetActive(false);
        settings.SetActive(false);
        keyboard.SetActive(false);
        controller.SetActive(false);
    }

    public void PlayGame()
    {
        SceneManager.LoadScene("Level1");
    }

    public void SeeControlsMenu()
    {
        main.SetActive(false);
        credits.SetActive(false);
        controls.SetActive(true);
        settings.SetActive(false);
        keyboard.SetActive(true);
        controller.SetActive(false);
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
    }

    public void SeeSettingsMenu()
    {
        main.SetActive(false);
        credits.SetActive(false);
        controls.SetActive(false);
        settings.SetActive(true);
        keyboard.SetActive(false);
        controller.SetActive(false);
    }

    public void Back()
    {
        main.SetActive(true);
        credits.SetActive(false);
        controls.SetActive(false);
        settings.SetActive(false);
        keyboard.SetActive(false);
        controller.SetActive(false);
    }

    
    public void QuitGame()
    {
        Debug.Log("Quit Successful!");
        Application.Quit();
    }
}
