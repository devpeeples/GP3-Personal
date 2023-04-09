using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickup : MonoBehaviour
{
    //

         void Start()
    {
        //GetComponent<PlayerHealth>;
    }
     void OnTriggerEnter(Collider other)
    {
        //check if the one who enters the trigger has the player tag 
        //then check if the player can gather the pickup into a UI Variable 
        if (other.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            PlayerHealth currentHealth = other.gameObject.GetComponent<PlayerHealth>();
            //HealthBar SetHealth other.gameObject.GetComponent<HealthBar>();
            //if (currentHealth >= 0)
            {

                Destroy(gameObject);
                //adding the health goes here

            }
  
            }

        }

    }