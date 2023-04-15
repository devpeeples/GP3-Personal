using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public PlayerCurrencyUI playerCurrencyUI;
    public BubbleDash bubbleDash;
    public BubbleShield bubbleShield;
    public PlayerHealth playerHealth;
    public Grapple grapple; 
    public SwitchWeapon switchWeapon;

    void Awake()
    {

        DontDestroyOnLoad(gameObject);
    }

    public void SaveGameData()
    {
        SaveSystem.SavePlayer(playerCurrencyUI, bubbleDash, bubbleShield, playerHealth, grapple, switchWeapon);
    }
    public void LoadGameData()
    {
        
        PlayerData playerData = SaveSystem.LoadPlayer();
        if (playerData != null)
        {
            playerCurrencyUI.totalCurrency = playerData.currency;
            bubbleDash.dashDuration = playerData.dashTime;
            bubbleShield.shieldTime = playerData.shieldTime;
            playerHealth.maxCharge = playerData.maxCharge;
            grapple.stunTime = playerData.stunTime;
            switchWeapon.isSwitched = intToBool(playerData.isSwitched);
            switchWeapon.BoolToAction();


        }
    }


    public bool intToBool(int intNum)
    {
        if (intNum == 0 )
        {
            return false; 
        }
        else
        {
            return true; 
        }
    }
    
}

