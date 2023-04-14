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
      healthIncrease = 25;
    }

    void OnTriggerEnter(Collider other)
    {
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