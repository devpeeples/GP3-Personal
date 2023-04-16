using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private PlayerCurrencyUI playerCurrencyUI;
    private BubbleDash bubbleDash;
    private BubbleShield bubbleShield;
    private PlayerHealth playerHealth;
    private Grapple grapple; 
    private SwitchWeapon switchWeapon;
    public bool gameLoaded = false;
    private GameObject[] playerList;
    private GameObject playerObject;
    private GameObject playerCurrencyUIObject;


    // time to make a million references lets goo



    void Awake()
    {

        DontDestroyOnLoad(gameObject);

    }
    public void References() 
    { 

        playerList = GameObject.FindGameObjectsWithTag("Player");
        foreach (GameObject playerObject in playerList)
        {
            if (playerObject.GetComponent<PlayerHealth>() != null)
            {
                //playerHealthObject = playerObject;

                


                playerHealth = playerObject.GetComponent<PlayerHealth>();
                grapple = playerObject.GetComponentInChildren<Grapple>();
                bubbleDash = playerObject.GetComponent<BubbleDash>();
                bubbleShield = playerObject.GetComponent<BubbleShield>();
                switchWeapon = playerObject.GetComponentInChildren<SwitchWeapon>();
                Debug.Log(playerObject);

            }
            if (playerObject.GetComponent<PlayerCurrencyUI>() != null)
            {
                playerCurrencyUIObject = playerObject;
                playerCurrencyUI = playerCurrencyUIObject.GetComponent<PlayerCurrencyUI>();

            }
        }

    }

    public void SaveGameData()
    {
        References();
        Debug.Log("Save Game Data called");
        SaveSystem.SavePlayer(playerCurrencyUI, bubbleDash, bubbleShield, playerHealth, grapple, switchWeapon);
    }
    public void LoadGameData()
    {
        References();

        Debug.Log("Load Game Data called");
        PlayerData playerData = SaveSystem.LoadPlayer();
        if (playerData != null)
        {
            Debug.Log("Player data not null");
            Debug.Log(playerData.currency);
            Debug.Log(playerCurrencyUI.totalCurrency);
            playerCurrencyUI.totalCurrency = playerData.currency;
            bubbleDash.dashDuration = playerData.dashTime;
            bubbleShield.shieldTime = playerData.shieldTime;
            playerHealth.maxCharge = playerData.maxCharge;
            grapple.stunTime = playerData.stunTime;
            switchWeapon.isSwitched = intToBool(playerData.isSwitched);
            switchWeapon.BoolToAction();
            Debug.Log(playerCurrencyUI.totalCurrency);

        }
        gameLoaded = true; 
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

