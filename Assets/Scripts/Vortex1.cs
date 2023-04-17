using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Vortex1 : MonoBehaviour
{
   
    public bool level1;
    public bool level2;
    public bool level3;
    public bool hub;
    public bool win; 
    private SceneLoader sceneLoader;
    private GameObject gameManagerObject;
    private GameObject[] playerList;
    private GameObject player;


    void Start()
    {
        playerList = GameObject.FindGameObjectsWithTag("Player");
        foreach (GameObject playerObject in playerList)
        {
            if (playerObject.GetComponent<PlayerHealth>() != null)
            {
                player = playerObject;
            }

        }
        gameManagerObject = GameObject.Find("GameManager");
        sceneLoader = gameManagerObject.GetComponent<SceneLoader>();

    }


    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject == player)

        {
            //Debug.Log("player");
            if (level1)
            {
                sceneLoader.CallLoadScene("Level1");
                //SceneManager.LoadScene("Level1");

            }
            else if (level2)
            {
                sceneLoader.CallLoadScene("Level2");
            }
            else if (level3)
            {
                sceneLoader.CallLoadScene("Level3");
            }
            else if (hub)
            {
                SceneManager.LoadScene("PHub");
            }
            else if (win)
            {
                SceneManager.LoadScene("WinScreen");
            }
        }
        else
        {
           // Debug.Log("not player");
        }
        

    }
}
