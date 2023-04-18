using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FreezePlayer : MonoBehaviour
{
   


    private bool shootingOn;
    private GameObject[] playerList;
    private GameObject player;


    void Awake()
    {
        playerList = GameObject.FindGameObjectsWithTag("Player");
        foreach (GameObject playerObject in playerList)
        {
            if (playerObject.GetComponent<PlayerHealth>() != null)
            {
                player = playerObject;
            }

        }

    }

    void OnEnable()
    {
        
        if (player != null)
        {
            Time.timeScale = 0f;
            player.GetComponent<MovementRB>().speed = 0;
            player.GetComponent<MovementRB>().rotationSpeed = 0;
            player.GetComponentInChildren<Grapple>().enabled = false;
            player.GetComponent<BubbleDash>().enabled = false;
            player.GetComponent<BubbleShield>().enabled = false;



            if (player.GetComponentInChildren<RBPlayerShooting>().enabled)
            {
                shootingOn = false;
                player.GetComponentInChildren<RBPlayerShooting>().enabled = false;
            }
            else if (player.GetComponentInChildren<PlayerShooting2>().enabled)
            {
                shootingOn = true;
                player.GetComponentInChildren<PlayerShooting2>().enabled = false;
            }
        }
        


    }

    // Update is called once per frame
    void OnDisable()
    {

        if (player != null)
        {
            Time.timeScale = 1f;
            player.GetComponent<MovementRB>().rotationSpeed = player.GetComponent<MovementRB>().setRotationSpeed;
            player.GetComponent<MovementRB>().speed = player.GetComponent<MovementRB>().setSpeed;
            player.GetComponentInChildren<Grapple>().enabled = true;
            player.GetComponent<BubbleDash>().enabled = true;
            player.GetComponent<BubbleShield>().enabled = true;
            if (!shootingOn)
            {
                player.GetComponentInChildren<RBPlayerShooting>().enabled = true;
            }
            else if (shootingOn)
            {
                player.GetComponentInChildren<PlayerShooting2>().enabled = true;
            }
        }
    }

}
