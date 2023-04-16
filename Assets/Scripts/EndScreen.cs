using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndScreen : MonoBehaviour
{
    
    public GameObject LoseScreen;
    public GameObject Credits;
    private GameObject player;
    private PlayerHealth playerHealth;
    private PlayerCurrencyUI playerCurrency; 
    private SceneLoader sceneLoader;
    private GameObject gameManagerObject;

    private GameObject[] players; 

    void Start()
    {
        LoseScreen.SetActive(true);
        Credits.SetActive(false);
        gameManagerObject = GameObject.Find("GameManager");
        sceneLoader = gameManagerObject.GetComponent<SceneLoader>();
    }

    public void RestartLevel()
    {
        ResetPlayer();

        sceneLoader.CallLoadScene("Level1"); //which level you want to restart to.
    }

    public void MainMenu()
    {
        ResetPlayer();
        sceneLoader.CallLoadScene("MainMenu");
        //SceneManager.LoadScene("MainMenu"); 
    }

    public void BackToHub()
    {
        ResetPlayer();
        sceneLoader.CallLoadScene("PHUb");
        //SceneManager.LoadScene("MainMenu");
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
        ResetPlayer();   
        Debug.Log("Quit Successful");
        Application.Quit();
    }

    private void ResetPlayer()
    {
        players = GameObject.FindGameObjectsWithTag("Player");
        foreach (GameObject player in players)
        {
            if (player.GetComponent<PlayerHealth>())
            {
                playerHealth = player.GetComponent<PlayerHealth>();
                playerHealth.resetCharge();
                playerHealth.resetHealth();


            }
            if (player.GetComponent<PlayerCurrencyUI>())
            {

                playerCurrency = player.GetComponent<PlayerCurrencyUI>();
                playerCurrency.RobPlayer();


            }
        }
    }
}
