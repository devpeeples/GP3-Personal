using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChargePickUp : MonoBehaviour
{
    //private PlayerHealth currentCharge;
    public int chargeIncrease;
    //public HealthBar healthBar;
    //audio
    public AudioSource source;
    private PlayerHealth playerHealth;

    void OnTriggerEnter(Collider other)
    {
        //Debug.Log("health in space");
        if (other.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            //Debug.Log("health player");

            playerHealth = other.GetComponentInParent<PlayerHealth>();

            //AudioSource source = GameObject.FindWithTag()
            //Debug.Log("Playerhealth: " + playerHealth);

            if (playerHealth != null)
            {
                playerHealth.AddCharge(chargeIncrease);
                if (source != null)
                {
                    source.Play();
                }
                Destroy(gameObject);
                //Debug.Log ("Health Increased");
            }

        }

    }
}
