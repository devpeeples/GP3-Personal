using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class RBPlayerShooting : MonoBehaviour
{
    public GameObject bullet;
    public float shotSpeed;

    private GameObject shot;
    //audio
    public AudioSource source;
    public AudioClip clip; 



    void Start()
    {
        
    }
    void Update()
    {
        if (Input.GetButtonDown("Shoot"))
        {
            source.PlayOneShot(clip);
            RbPlayerShoot();
        }
            
    }

    void RbPlayerShoot()
    {
       
        shot = Instantiate(bullet, transform.position, transform.rotation) as GameObject;
        shot.gameObject.GetComponent<Rigidbody>().AddForce(transform.forward * shotSpeed);
        
    }
}