using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    [Header("Health Variables")]
    public static int maxHealth = 100;
    [SerializeField] public static int currentHealth;

    [Header("Charge Variables")]
    public static int maxCharge = 10;
    [SerializeField] public static int currentCharge;


    [Header("References")]
    public HealthPickup healthIncrease;
    public HealthBar healthBar;
    public ChargeBar chargeBar;
    public BubbleDash bubbleDash;
    //audio
    public AudioSource source;
    public void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
        
        currentCharge = maxCharge;
        chargeBar.SetMaxCharge(maxCharge);
    }

    // Update is called once per frame


    public void TakeDamage(int damage)
    {
        if (!bubbleDash.isInvincible)
        {
            source.Play();
            currentHealth -= damage;

            healthBar.SetHealth(currentHealth);
            if (currentHealth <= 0)
            {
                SceneManager.LoadScene("LoseScreen");
            }
        }
    }


    public void UseCharge(int used)
    {
        currentCharge -= used;

        chargeBar.SetCharge(currentCharge);
    }
}