using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndScreen : MonoBehaviour
{
    
    public GameObject LoseScreen;
    public GameObject Credits;

    void Start()
    {
        LoseScreen.SetActive(true);
        Credits.SetActive(false);
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene("Level1"); //which level you want to restart to.
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu"); //main menu
    }

    public void BackToHub()
    {
        Debug.Log("Hub Successful");
        //eg. "SceneManager.LoadScene("Hub World");"
    }

    public void SeeCredits()
    {
        LoseScreen.SetActive(false);
        Credits.SetActive(true);
    }

    public void Back()
    {
        LoseScreen.SetActive(true);
        Credits.SetActive(false);
    }

    public void QuitGame()
    {
        Debug.Log("Quit Successful");
        Application.Quit();
    }
}
