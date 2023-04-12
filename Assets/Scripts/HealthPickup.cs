using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickup : MonoBehaviour
{
    public PlayerHealth currentHealth;
    public int healthIncrease;
    public HealthBar healthBar;
    //audio
    public AudioSource source;

    void Start()
    {
      healthIncrease = 10;
    }

    void OnTriggerEnter(Collider other)
    {
        //HealthBar SetHealth other.gameObject.GetComponent<HealthBar>();
        //PlayerHealth currentHealth = other.GetComponent<PlayerHealth>();
            if (other.gameObject.layer == LayerMask.NameToLayer("Player"))
            {
              if (currentHealth != null)
              {
              PlayerHealth.currentHealth += healthIncrease;
              source.Play();
              Destroy(gameObject);
              Debug.Log ("Health Increased");
              }
            
            }
    }
}