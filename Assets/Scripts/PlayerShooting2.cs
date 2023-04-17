using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting2 : MonoBehaviour
{
    public AudioSource source;
    public GameObject superShot;
    public GameObject normalShot; 
    public float shotSpeed;
    public float chargeTime; 




    private GameObject shotInstance; 
    private GameObject superShotInstance;
    //[SerializedField]
    private float chargeTimer = 0 ;
    private bool hasShot;

    //private bool OneShot;
    //private Vector3 startingScale; 




    // Update is called once per frame
    void Update()
    {
        


        if (Input.GetButton("Shoot") || Input.GetAxis("Shoot") >= 0.5f) // check for both mouse and controller input
        {
            hasShot = false;
            chargeTimer += Time.deltaTime;
        }

        if ((Input.GetButtonUp("Shoot") && (chargeTimer >= chargeTime)) || (Input.GetAxis("Shoot") < 0.5f && (chargeTimer >= chargeTime))) // check for both mouse and controller input
        {
            SuperPlayerShoot();
            chargeTimer = 0;
            
        }
        else if ((Input.GetButtonUp("Shoot") && (chargeTimer < chargeTime)) || (Input.GetAxis("Shoot") < 0.5f && (chargeTimer < chargeTime))) // check for both mouse and controller input
        {
            playerShoot();
            chargeTimer = 0;
            
        }
   

        //Controller support 
        /*
        if (Input.GetAxis("Shoot") >= 0.5)
        {
            chargeTimer += Time.deltaTime;
        }
        if (Input.GetAxis("Shoot") >= 0.5 && (chargeTimer >= chargeTime))
        {
            SuperPlayerShoot();
            //OneShot = true;
            chargeTimer = 0;

        }
        else if (Input.GetAxis("Shoot") >= 0.5 && (chargeTimer < chargeTime))
        {
            playerShoot();
            chargeTimer = 0;
        }
        */


    }



    void SuperPlayerShoot()
    {
        if (!hasShot)
        {
            superShotInstance = Instantiate(superShot, transform.position, transform.rotation) as GameObject;
            if (superShotInstance != null)
            {
                if (source != null)
                {
                    source.Play();
                }
                superShotInstance.gameObject.GetComponent<Rigidbody>().AddForce(transform.forward * shotSpeed);
            }
            hasShot = true;
        }
    }


    void playerShoot()
    {
        if (!hasShot)
        {
            shotInstance = Instantiate(normalShot, transform.position, transform.rotation) as GameObject;
            if (shotInstance != null)
            {
                if (source != null)
                {
                    source.Play();
                }
                shotInstance.gameObject.GetComponent<Rigidbody>().AddForce(transform.forward * shotSpeed);
            }
            hasShot = true;
        }
        
    }
}
