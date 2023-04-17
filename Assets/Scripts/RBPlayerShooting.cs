using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class RBPlayerShooting : MonoBehaviour
{
    //public AudioManager audioManager;
    public AudioSource source;
    public GameObject bullet;
    public float shotSpeed;

    private GameObject shot;
    private bool hasShot;
    //private AudioManager audioManager;



    void Update()
    {
        if (Input.GetButtonDown("Shoot"))
        {
            if (source != null)
            {
                source.Play();
            }
            //audioManager.Play("PlayerBullet");
            RbPlayerShoot();
        }
        if(Input.GetAxis("Shoot") >= 0.5)
        {
            if (source != null)
            {
                source.Play();
            }
            //audioManager.Play("PlayerBullet");
            RbPlayerShoot();
        }
        if (Input.GetButtonUp("Shoot") || Input.GetAxis("Shoot") < 0.5)
        {
            hasShot = false;
        }

    }

    void RbPlayerShoot()
    {
        if (!hasShot)
        {
            shot = Instantiate(bullet, transform.position, transform.rotation) as GameObject;
            shot.gameObject.GetComponent<Rigidbody>().AddForce(transform.forward * shotSpeed);
            hasShot = true;
        }
    }
}
