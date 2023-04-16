using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleShield : MonoBehaviour
{
    public GameObject shield;
    public float shieldTime;
    public int shieldCharge;
    //public AudioManager am;

    public AudioSource source;


    private PlayerHealth playerHealth;
    private bool chargeCheck;


    public void IncreaseTime(float amount)
    {
        shieldTime += amount;
    }

    void OnEnable()
    {
        //get component for the player health

        playerHealth = GetComponent<PlayerHealth>();
    }



    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("BubbleShield"))
        {
            //check charge amount 
            chargeCheck = playerHealth.ChargeCheck(shieldCharge);

            if (chargeCheck)
            {
                playerHealth.UseCharge(shieldCharge);

                //am.Play("ShieldActivate");
                if (source != null)
                {
                    source.Play();
                }
                shield.gameObject.SetActive(true);
                Invoke("DownShield", shieldTime);

            }



        }
    }
    void DownShield()
    {

        shield.gameObject.SetActive(false);
    }
}
