using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickup : MonoBehaviour
{
    private PlayerHealth currentHealth;
    public int healthIncrease;
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
                playerHealth.AddHealth(healthIncrease);
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