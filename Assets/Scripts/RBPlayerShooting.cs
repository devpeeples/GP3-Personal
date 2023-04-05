using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class RBPlayerShooting : MonoBehaviour
{
    public GameObject audioManagerObject;
    public GameObject bullet;
    public float shotSpeed;

    private GameObject shot;
    private AudioManager audioManager;
    public float fireRate;
    public float delayRate;
    private bool isShooting = false;

    public bool isShotgun;

    void Start()
    {
        
    }
    void Update()
    {
        if (Input.GetButton("Shoot"))
        {
            audioManagerObject.GetComponent<AudioManager>().Play("PlayerBullet");
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
