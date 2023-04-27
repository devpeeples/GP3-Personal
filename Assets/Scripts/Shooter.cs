using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    
    public GameObject bullet; 
    public float spawnRate; 
    public float spawnDelay; 
    public float shotSpeed;
    //public GameObject audioManagerObject; 

    private GameObject shot;
    public AudioSource source; 
    public AudioClip clip;

    private GameObject[] playerList;
    private Transform player;


    void Start()
    {
        playerList = GameObject.FindGameObjectsWithTag("Player");
        foreach (GameObject playerObject in playerList)
        {
            if (playerObject.GetComponent<PlayerHealth>() != null)
            {
                player = playerObject.transform;
            }

        }
    
        InvokeRepeating("Shoot",spawnDelay, spawnRate);   
    }

    void Update()
    {
        gameObject.transform.LookAt(player);
    }
    void Shoot(){
        if(gameObject.active){
            if (source != null)
            {
                source.PlayOneShot(clip);
            }
            //audioManagerObject.GetComponent<AudioManager>().Play("EnemyBullet");
            shot = Instantiate(bullet,transform.position,transform.rotation);
            shot.gameObject.GetComponent<Rigidbody>().AddForce(transform.forward*shotSpeed);
        }
        
    }


}
