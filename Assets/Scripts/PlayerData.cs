using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData 
{

    public int currency;
    public float dashTime;
    public float shieldTime;
    public int maxCharge;
    public float stunTime;
    public int isSwitched;

    public PlayerData(PlayerCurrencyUI playerCurrencyUI, BubbleDash bubbleDash, BubbleShield bubbleShield, PlayerHealth playerHealth, Grapple grapple, SwitchWeapon switchWeapon)
    {
        currency = playerCurrencyUI.totalCurrency;
        dashTime = bubbleDash.dashDuration;
        shieldTime = bubbleShield.shieldTime;
        maxCharge = playerHealth.maxCharge;
        stunTime = grapple.stunTime;
        isSwitched = boolToInt(switchWeapon.isSwitched); 

    }
    public int boolToInt(bool boolCheck)
    {
        if (boolCheck == true)
        {
            return 1;
        }
        else
            return 0;

    }
  

}
