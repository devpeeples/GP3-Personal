using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinimapController : MonoBehaviour
{
    private GameObject[] players;
    //private GameObject playerObject; 
    private Transform playerTransform;


    void Start()
    {
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
        newPositon.y = transform.position.y;
        transform.position = newPositon;
    }
}
