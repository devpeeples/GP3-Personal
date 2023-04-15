using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoralPickUp : MonoBehaviour
{
    public int chargeValue;


    private PlayerHealth playerHealth = null;
    void OnTriggerEnter(Collider other)
    {
        //check if the one who enters the trigger has the player tag 
        //then check if the player can gather the pickup into a UI Variable 
        if (other.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
           
            PlayerHealth playerHealth = other.gameObject.GetComponentInParent<PlayerHealth>();
            if (playerHealth != null)
            {
       
                playerHealth.AddCharge(chargeValue);
                Destroy(gameObject);
            }
            else
            {
                Debug.Log("Please put the PlayerCurrencyUI script on the player model of the player, make sure it has a collider, and the player model has a player tag.");
            }

        }

    }

}
