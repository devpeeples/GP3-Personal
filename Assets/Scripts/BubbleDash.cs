using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleDash : MonoBehaviour
{
    [Header("References")]
    public Transform orientation;
    private Rigidbody rb;
    public AudioManager aM;

    private PlayerHealth playerHealth;
    private bool chargeCheck;

    [Header("Bool States")]
    public bool isDashing;
    public bool isInvincible;



    [Header("Dashing")]
    public float dashForce;
    public float dashUpwardForce;

    //dash duration is what gets saved
    public float dashDuration;
    public int dashCharge;

    [Header("Cooldown")]
    public float dashCd;
    private float dashCdTime;


    /*
    
    public void SaveDash()
    {
        SaveSystem.SavePlayer(this);
    }
    public void LoadDash()
    {
        PlayerData data = SaveSystem.LoadPlayer();
        totalCurrency = data.currency;
    }
    */

    // Start is called before the first frame update
    void OnEnable()
    {
        //get component for the player health

        playerHealth = GetComponent<PlayerHealth>();
    }
    void Start()
    {
        isDashing = false;
        isInvincible = false;
        rb = GetComponent<Rigidbody>();

    }

    void Update()
    {
        if (Input.GetButtonDown("BubbleDash"))
        {
            chargeCheck = playerHealth.ChargeCheck(dashCharge);
            if (chargeCheck)
            {
                playerHealth.UseCharge(dashCharge);

                Dash();

            }
        }



        if (dashCdTime > 0)
            dashCdTime -= Time.deltaTime;
    }


    public void IncreaseDash(float amount)
    {
        dashDuration += amount;
    }

    private void Dash()
    {
        // disable player movement? 
        // check charge amount 
        //use charge 


        aM.Play("Dashing");
        if (dashCdTime > 0) return;
        else dashCdTime = dashCd;

        isDashing = true;
        isInvincible = true;
        Vector3 forceToApply = orientation.forward * dashForce + orientation.up * dashUpwardForce;

        rb.AddForce(forceToApply, ForceMode.Impulse);

        Invoke(nameof(ResetDash), dashDuration);
    }

    private void ResetDash()
    {
        isDashing = false;
        isInvincible = false;
    }
    public void Invincibility(float time)
    {
        isInvincible = true;
        Invoke(nameof(StopInvincibility), time);
    }
    private void StopInvincibility()
    {
        isInvincible = false;
    }


}