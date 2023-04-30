using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleDash : MonoBehaviour
{
    [Header("References")]
    public Transform orientation;
    private Rigidbody rb;

    public AudioSource source;
    public ParticleSystem particleDash; 

    //public AudioManager aM;

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

        //Debug.Log(Input.GetAxis("BubbleDash"));


        if (dashCdTime > 0)
            dashCdTime -= Time.deltaTime;
    }


    public void IncreaseDash(float amount)
    {
        dashDuration += amount;
    }
    //old dash that cuases goingt hroguh wall collider glitch 
    /*
    private void Dash()
    {
        // disable player movement? 
        // check charge amount 
        //use charge 
        if (source != null)
        {
            source.Play();
        }


        if (particleDash != null)
        {
            particleDash.gameObject.SetActive(true);
            particleDash.loop = true;
            particleDash.Play();
        }
        //aM.Play("Dashing");
        if (dashCdTime > 0) return;
        else dashCdTime = dashCd;

        isDashing = true;
        isInvincible = true;
        Vector3 forceToApply = orientation.forward * dashForce + orientation.up * dashUpwardForce;

        rb.AddForce(forceToApply, ForceMode.Impulse);
      
        Invoke(nameof(ResetDash), dashDuration);
    }
    */
    //new dash that hopefully fixes things
    private void Dash()
    {
       
        if (source != null)
        {
            source.Play();
        }

        if (particleDash != null)
        {
            particleDash.gameObject.SetActive(true);
            particleDash.loop = true;
            particleDash.Play();
        }

        //aM.Play("Dashing");
        if (dashCdTime > 0) return;
        else dashCdTime = dashCd;

        isDashing = true;
        isInvincible = true;
        Vector3 forceToApply = orientation.forward * dashForce + orientation.up * dashUpwardForce;


        
        // Use a Raycast to detect collisions in front of the player during the dash
        RaycastHit hit;
        if (Physics.Raycast(transform.position, orientation.forward, out hit, 2, LayerMask.GetMask("Default")))
        {
            Debug.Log(" Raycast hit with layer default");
            Debug.Log("Raycast hit with layer default on object: " + hit.transform.gameObject.name);
            // If a collision is detected, stop the player's movement
            rb.velocity = Vector3.zero;
            ResetDash();
            return;
        }
        rb.AddForce(forceToApply, ForceMode.Impulse);
        Invoke(nameof(ResetDash), dashDuration);
    }

    private void ResetDash()
    {
        isDashing = false;
        if (particleDash != null)
        {
            particleDash.gameObject.SetActive(false);
        }
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