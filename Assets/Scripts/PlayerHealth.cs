using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    [Header("Health Variables")]
    public int maxHealth = 100;
    [SerializeField] private int currentHealth;

    [Header("Charge Variables")]
    public int maxCharge = 10;
    [SerializeField] private int currentCharge;


    [Header("References")]
    public HealthBar healthBar;
    public ChargeBar chargeBar;
    public BubbleDash bubbleDash;
    public AudioManager audioManager;

    void Start()
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
            audioManager.Play("PlayerHit");
            currentHealth -= damage;

            healthBar.SetHealth(currentHealth);
            if (currentHealth <= 0)
            {
                SceneManager.LoadScene("LoseScreen");
            }
        }
        
    }

    void UseCharge(int used)
    {
        currentCharge -= used;

        chargeBar.SetCharge(currentCharge);
    }
}
