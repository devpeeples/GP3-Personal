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
    //charged up shot
    [SerializeField] public GameObject chargedBullet;
    [SerializeField] public GameObject chargedShot;
    [SerializeField] private float chargedSpeed;
    [SerializeField] private float chargedTime;
    private bool isCharging;


    void Start()
    {
        
    }
    void Update()
    {
       
     
     if (Input.GetButtonDown("Shoot") && chargedTime <2)
        {
            isCharging = true;
            if(isCharging == true)
            {
                chargedTime += Time.deltaTime*chargedSpeed;
            }
     
     if (Input.GetButtonDown("Shoot"))
        {
            shot = Instantiate(bullet, transform.position, transform.rotation) as GameObject;
            shot.gameObject.GetComponent<Rigidbody>().AddForce(transform.forward * shotSpeed);
            chargedTime = 0;
            source.Play();
        }
            else if(Input.GetButtonUp("Shoot") && chargedTime >=2)
            {
                chargedShot = Instantiate(chargedBullet, transform.position, transform.rotation) as GameObject;
                chargedShot.gameObject.GetComponent<Rigidbody>().AddForce(transform.forward * shotSpeed);
                isCharging = false;
                chargedTime = 0;
            }

         
        }
            
    }
    //void ReleaseCharge()
   // {
        
   // }
}