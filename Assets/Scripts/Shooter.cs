using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    
    public GameObject bullet; 
    public Transform player; 
    public float spawnRate; 
    public float spawnDelay; 
    public float shotSpeed;
    private GameObject shot;
    //audio
    public AudioSource source;


    void Start()
    {

       InvokeRepeating("Shoot",spawnDelay, spawnRate);   
    }

    void Update()
    {
        transform.LookAt(player);
    }
    void Shoot(){
        if(gameObject.active)
        {
            source.Play();
            shot = Instantiate(bullet,transform.position,transform.rotation);
            shot.gameObject.GetComponent<Rigidbody>().AddForce(transform.forward*shotSpeed);
        }
        
    }


}
