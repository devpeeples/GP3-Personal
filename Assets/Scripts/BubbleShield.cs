using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleShield : MonoBehaviour
{
    public GameObject shield;
    public float shieldTime;
    public AudioManager am; 


    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("BubbleShield"))
        {
            am.Play("ShieldActivate");
            shield.gameObject.SetActive(true);
            Invoke("DownShield", shieldTime);
        }
    }
    void DownShield()
    {
        shield.gameObject.SetActive(false);
    }
}
