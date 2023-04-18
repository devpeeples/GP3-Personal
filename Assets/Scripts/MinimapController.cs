using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinimapController : MonoBehaviour
{
    private GameObject[] players;
    //private GameObject playerObject; 
    private Transform playerTransform;
    private float startingY; 


    void Start()
    {
        startingY = transform.position.y; 
        players = GameObject.FindGameObjectsWithTag("Player");
        foreach (GameObject player in players)
        {
            if (player.GetComponent<PlayerHealth>() != null)
            {

                playerTransform = player.transform;
            }
        }

    }


    void LateUpdate()
    {
        Vector3 newPositon = playerTransform.position;
        newPositon.y = startingY;
        Debug.Log(newPositon.y);
        transform.position = newPositon;
        Debug.Log(transform.position);
    }
}
