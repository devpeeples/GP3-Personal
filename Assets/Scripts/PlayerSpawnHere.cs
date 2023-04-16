using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawnHere : MonoBehaviour
{
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

                player.transform.position = gameObject.transform.position;


            }

        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
