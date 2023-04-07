using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class RBPlayerShooting : MonoBehaviour
{
    public GameObject bullet;
    public float shotSpeed;

    private GameObject shot;
    public float fireRate;
    public float delayRate;
    private bool isShooting = false;

    public bool isShotgun;
    //audio
     public AudioSource source;
    public AudioClip clip; 


    void Start()
    {
        
    }
    void Update()
    {
        if (Input.GetButton("Shoot"))
        {
            source.PlayOneShot(clip);
            trueShoot();
            InvokeRepeating("RbPlayerShoot", delayRate, fireRate);
            //isShooting = true; 
            //RbPlayerShoot();
        }

        if (Input.GetButtonUp("Shoot"))
        {
            falseShoot();
        }
            
    }
    void trueShoot(){
        isShooting = true; 
    }
    void falseShoot(){
        isShooting = false; 
    }

    void RbPlayerShoot()
    {
        if (isShooting){
            shot = Instantiate(bullet, transform.position, transform.rotation) as GameObject;
            shot.gameObject.GetComponent<Rigidbody>().AddForce(transform.forward * shotSpeed);
            //isShooting = false; 
            //Invoke(delayMethod, fireRate);

        }        
    }

}
