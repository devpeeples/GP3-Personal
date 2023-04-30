
using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class BubbleShield : MonoBehaviour

{
    public GameObject shield;
    public float shieldTime;
    public int shieldCharge;
    public AudioSource source;
    public Material normalMaterial;
    public Material flickerMaterial;

    private PlayerHealth playerHealth;
    private bool chargeCheck;
    private Renderer shieldRenderer;

    public void IncreaseTime(float amount)
    {
        shieldTime += amount;
    }

    void OnEnable()
    {
        playerHealth = GetComponent<PlayerHealth>();
        shieldRenderer = shield.GetComponent<Renderer>();
    }

    void Update()
    {
        if (Input.GetButtonDown("BubbleShield"))
        {
            chargeCheck = playerHealth.ChargeCheck(shieldCharge);

            if (chargeCheck)
            {
                playerHealth.UseCharge(shieldCharge);

                if (source != null)
                {
                    source.Play();
                }
                shield.gameObject.SetActive(true);
                StartCoroutine(FlickerShield(shieldTime - 1f)); // start the flicker Coroutine with a delay of 1 second before the shield expires
                Invoke("DownShield", shieldTime);
            }
        }
    }

    IEnumerator FlickerShield(float remainingTime)
    {
        float interval = 0.1f;
        float timeFactor = 1.0f;

        while (remainingTime > 0f)
        {
            if (remainingTime < 1f)
            {
                timeFactor = Mathf.Sin(20f * Time.time) + 1.0f;
            }
            Color flickerColor = Color.Lerp(normalMaterial.color, flickerMaterial.color, timeFactor);
            shieldRenderer.material.color = flickerColor;
            yield return new WaitForSeconds(interval);
            remainingTime -= interval;
        }
        shieldRenderer.material = normalMaterial;
    }

    void DownShield()
    {
        shield.gameObject.SetActive(false);
    }
}
