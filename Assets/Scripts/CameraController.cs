using UnityEngine;

public class CameraController : MonoBehaviour
{


    private Transform player;
    //public Vector3 offset;
    private GameObject[] playerList;
    private GameObject playerObject;


    void Start()
    {
        playerList = GameObject.FindGameObjectsWithTag("Player");
        foreach (GameObject playerObject in playerList)
        {
            if (playerObject.GetComponent<PlayerHealth>() != null)
            {
                player = playerObject.GetComponent<Transform>(); 

            }

        }
    }
    void Update()
    {
        transform.position = player.position;
    }
}
