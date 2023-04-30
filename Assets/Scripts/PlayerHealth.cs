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
    public AudioSource source;
    public ParticleSystem hitParticle;
    //public AudioManager audioManager;


    public void resetCharge()
    {
        currentCharge = maxCharge;
        
        chargeBar.SetCharge(currentCharge);

    }
    public void resetHealth()
    {
        currentHealth = maxHealth;
        healthBar.SetHealth(currentHealth);

    }
    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
        
        currentCharge = maxCharge;
        chargeBar.SetMaxCharge(maxCharge);
    }
    public void AddHealth(int healthAdd)
    {
        if ((currentHealth + healthAdd) <= maxHealth)
        {

            currentHealth += healthAdd;
            healthBar.SetHealth(currentHealth);
        }
        else
        {
            currentHealth = maxHealth;
            healthBar.SetHealth(currentHealth);
            // what else would you want to do if you dont add charge?
        }

    }
    // Update is called once per frame


    public void TakeDamage(int damage)
    {
        if (!bubbleDash.isInvincible)
        {
            if (source != null)
            {
                source.Play();
            }
            //audioManager.Play("PlayerHit");

            currentHealth -= damage;

            healthBar.SetHealth(currentHealth);
            if (currentHealth <= 0)
            {
                SceneManager.LoadScene("LoseScreen");
            }
            if(hitParticle != null)
            {
                hitParticle.gameObject.SetActive(true);
                hitParticle.Play();

            }
        }
        
    }

    public void UseCharge(int used)
    {
        currentCharge -= used;

        chargeBar.SetCharge(currentCharge);
    }

    public void AddCharge(int chargeAdd)
    {
        if ((currentCharge + chargeAdd) <= maxCharge)
        {

            currentCharge += chargeAdd;
            chargeBar.SetCharge(currentCharge);
        }
        else
        {

            // what else would you want to do if you dont add charge?
        }

    }
    public void AddMaxCharge(int maxAdd)
    {
        maxCharge += maxAdd;
    }


    public bool ChargeCheck(int amount)
    {
        if (currentCharge < amount)
        {
            return false;
        }
        else
        {
            return true;
        }

    }




}
