using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class RBPlayerShooting : MonoBehaviour
{
    public AudioManager audioManager;
    public GameObject bullet;
    public float shotSpeed;

    private GameObject shot;
    //private AudioManager audioManager;



    void Update()
    {
        if (Input.GetButtonDown("Shoot"))
        {

            audioManager.Play("PlayerBullet");
            RbPlayerShoot();
        }

    }

    void RbPlayerShoot()
    {

        shot = Instantiate(bullet, transform.position, transform.rotation) as GameObject;
        shot.gameObject.GetComponent<Rigidbody>().AddForce(transform.forward * shotSpeed);

    }
}
