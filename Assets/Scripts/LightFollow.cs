using UnityEngine;

public class LightFollow : MonoBehaviour
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
        transform.position = new Vector3(player.position.x, transform.position.y, player.transform.position.z);
    }
}
