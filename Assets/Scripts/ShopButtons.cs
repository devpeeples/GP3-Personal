using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopButtons : MonoBehaviour
{
    // Start is called before the first frame update

    private PlayerCurrencyUI playerCurrency; 
    private PlayerHealth playerHealth;
    private Grapple grapple;
    private BubbleDash bubbleDash;
    private BubbleShield bubbleShield;


    //    private RBPlayerShooting playerShooting;
    //private PlayerShooting2 playerShooting2;
    private SwitchWeapon switchWeapon; 
    private GameObject[] playerObjects;
    private GameObject playerCurrencyUIObject;



    //private bools that check if buttons are enabled or not? 




    [Header("Button Game Object Refs")]
    public GameObject coralButton1;
    public GameObject coralButton2;
    public GameObject coralButton3;

    public GameObject grappleButton1;
    public GameObject grappleButton2;
    public GameObject grappleButton3;

    public GameObject dashButton1;
    public GameObject dashButton2;
    public GameObject dashButton3;

    public GameObject shieldButton1;
    public GameObject shieldButton2;
    public GameObject shieldButton3;

    public GameObject weaponButton1; 





    [Header("CoralUp = cost, CoralUpCharge = amount added")]
    public int coralUp1;
    public int coralUp1Charge; 
    public int coralUp2;
    public int coralUp2Charge; 
    public int coralUp3;
    public int coralUp3Charge;




    [Header("DashUp = cost, DashUpCharge = Time added")]
    public int dashUp1;
    public float dashUp1Force;
    public int dashUp2;
    public float dashUp2Force;
    public int dashUp3;
    public float dashUp3Force;

    /*
    private bool grapple1Open;
    private bool grapple2Open;
    private bool grapple3Open;
    */


    [Header("GrappleUp = cost, GrappleUpStun = Time added")]
    public int grappleUp1;
    public float grappleUp1Stun;
    public int grappleUp2;
    public float grappleUp2Stun;
    public int grappleUp3;
    public float grappleUp3Stun;

    [Header("ShieldUp = cost, ShieldUpStun = Time added")]
    public int shieldUp1;
    public float shieldUp1Time;
    public int shieldUp2;
    public float shieldUp2Time;
    public int shieldUp3;
    public float shieldUp3Time;

    [Header("Weapon Upgrade ")]
    public int weaponUp1;
    //private bool weaponSwitch = false;


    private bool firstTime = true;




    [Header("ButtonBools Don't touch")]
    //these are for the save files
    public bool isGrappleOn = true;
    public bool isGrapple2On = false;
    public bool isGrapple3On = false;

    public bool isCoralOn = true;
    public bool isCoral2On = false;
    public bool isCoral3On = false;

    public bool isShieldOn = true;
    public bool isShield2On = false;
    public bool isShield3On = false;

    public bool isDashOn = true;
    public bool isDash2On = false;
    public bool isDash3On = false;

    public bool isWeaponOn = true;


    //methods for saving

    public void SaveShop()
    {
        SaveSystem.SaveShop(this);
    }
    public void LoadShop()
    {
        ShopData data = SaveSystem.LoadShop();
        isGrappleOn = IntToBool(data.grapple1button);
        isGrapple2On = IntToBool(data.grapple2button);
        isGrapple3On = IntToBool(data.grapple3button);

        isCoralOn = IntToBool(data.coral1button);
        isCoral2On = IntToBool(data.coral2button);
        isCoral3On = IntToBool(data.coral3button);

        isShieldOn = IntToBool(data.shield1button);
        isShield2On = IntToBool(data.shield2button);
        isShield3On = IntToBool(data.shield3button);

        isDashOn = IntToBool(data.dash1button);
        isDash2On = IntToBool(data.dash2button);
        isDash3On = IntToBool(data.dash3button);

        isWeaponOn = IntToBool(data.weapon1button);

    }

    private bool IntToBool(int buttonSave)
    {
        if (buttonSave == 0)
        {
            return false;
        }
        else
        {
            return true;
        }


    }



    private bool CheckInteractable(GameObject Button)
    {
        if (Button.GetComponent<Button>().interactable)
        {
            return true;
        }
        else
            return false; 

    }

    public void ReverseInteractable(bool istrue, GameObject Button)
    {
        if (istrue)
        {
            Button.GetComponent<Button>().interactable = true;
        }
        else
        {
            Button.GetComponent<Button>().interactable = false;
        }
    }


    public void OnEnable()
    {
        


        ReverseInteractable(isGrappleOn, grappleButton1);
        ReverseInteractable(isGrapple2On, grappleButton2);
        ReverseInteractable(isGrapple3On, grappleButton3);

        ReverseInteractable(isCoralOn, coralButton1);
        ReverseInteractable(isCoral2On, coralButton2);
        ReverseInteractable(isCoral3On, coralButton3);

        ReverseInteractable(isShieldOn, shieldButton1);
        ReverseInteractable(isShield2On, shieldButton2);
        ReverseInteractable(isShield3On, shieldButton3);

        ReverseInteractable(isDashOn, dashButton1);
        ReverseInteractable(isDash2On, dashButton2);
        ReverseInteractable(isDash3On, dashButton3);

        ReverseInteractable(isWeaponOn, weaponButton1);


        //Debug.Log("here: " + isGrappleOn);

        playerObjects = GameObject.FindGameObjectsWithTag("Player");
        foreach (GameObject playerObject in playerObjects)
        {
            if (playerObject.GetComponent<PlayerHealth>() != null)
            {
                //playerHealthObject = playerObject;
                playerHealth = playerObject.GetComponent<PlayerHealth>();
                grapple = playerObject.GetComponentInChildren<Grapple>();
                bubbleDash = playerObject.GetComponent<BubbleDash>();
                bubbleShield = playerObject.GetComponent<BubbleShield>();
                switchWeapon = playerObject.GetComponentInChildren<SwitchWeapon>();

            }
            if (playerObject.GetComponent<PlayerCurrencyUI>() != null)
            {
                playerCurrencyUIObject = playerObject;
                playerCurrency = playerCurrencyUIObject.GetComponent<PlayerCurrencyUI>();

            }
        }
       
    }

    public void CoralUpgrade1()
    {
        if (playerCurrency.CheckCurrency(coralUp1))
        {
            playerCurrency.SubtractCurrency(coralUp1);
            playerHealth.AddMaxCharge(coralUp1Charge);
            ButtonSwitch(coralButton1, coralButton2);
            isCoralOn = CheckInteractable(coralButton1);
            isCoral2On = CheckInteractable(coralButton2);
        }
        else
        {
            //can put code in case you can't afford something
        }
    }

    public void CoralUpgrade2()
    {
        if (playerCurrency.CheckCurrency(coralUp2))
        {
            playerCurrency.SubtractCurrency(coralUp2);
            playerHealth.AddMaxCharge(coralUp2Charge);
            ButtonSwitch(coralButton2, coralButton3);
            isCoral2On = CheckInteractable(coralButton2);
            isCoral3On = CheckInteractable(coralButton3);
        }
        else
        {
            //can put code in case you can't afford something
        }
    }

    public void CoralUpgrade3()
    {
        if (playerCurrency.CheckCurrency(coralUp3))
        {
            playerCurrency.SubtractCurrency(coralUp3);
            playerHealth.AddMaxCharge(coralUp3Charge);
            ButtonSwitch(coralButton3);
            isCoral3On = CheckInteractable(coralButton3);
        }
        else
        {
            //can put code in case you can't afford something
        }
    }





    public void GrappleUpgrade1()
    {
        if (playerCurrency.CheckCurrency(grappleUp1))
        {
            playerCurrency.SubtractCurrency(grappleUp1);
            grapple.IncreaseStun(grappleUp1Stun);
            ButtonSwitch(grappleButton1,grappleButton2);
            isGrappleOn = CheckInteractable(grappleButton1);
            isGrapple2On = CheckInteractable(grappleButton2);
        }
        else
        {
            //can put code in case you can't afford something
        }   
    }

    public void GrappleUpgrade2()
    {

        if (playerCurrency.CheckCurrency(grappleUp2))
        {
            playerCurrency.SubtractCurrency(grappleUp2);
            grapple.IncreaseStun(grappleUp2Stun);
            ButtonSwitch(grappleButton2, grappleButton3);
            isGrapple2On = CheckInteractable(grappleButton2);
            isGrapple3On = CheckInteractable(grappleButton3);

        }
        else
        {
            //can put code in case you can't afford something
        }
    }

    public void GrappleUpgrade3()
    {
        if (playerCurrency.CheckCurrency(grappleUp3))
        {
            playerCurrency.SubtractCurrency(grappleUp3);
            grapple.IncreaseStun(grappleUp3Stun);

            ButtonSwitch(grappleButton3);
            isGrapple3On = CheckInteractable(grappleButton3);
        }
        else
        {
            //can put code in case you can't afford something
        }

    }




    public void DashUpgrade1()
    {
        if (playerCurrency.CheckCurrency(dashUp1))
        {
            playerCurrency.SubtractCurrency(dashUp1);
            bubbleDash.IncreaseDash(dashUp1Force);
            ButtonSwitch(dashButton1, dashButton2);
            isDashOn = CheckInteractable(dashButton1);
            isDash2On = CheckInteractable(dashButton2);
        }
        else
        {
            //can put code in case you can't afford something
        }
    }

    public void DashUpgrade2()
    {

        if (playerCurrency.CheckCurrency(dashUp2))
        {
            playerCurrency.SubtractCurrency(dashUp2);
            bubbleDash.IncreaseDash(dashUp2Force);
            ButtonSwitch(dashButton2, dashButton3);
            isDash2On = CheckInteractable(dashButton2);
            isDash3On = CheckInteractable(dashButton3);
        }
        else
        {
            //can put code in case you can't afford something
        }
    }

    public void DashUpgrade3()
    {
        if (playerCurrency.CheckCurrency(dashUp3))
        {
            playerCurrency.SubtractCurrency(dashUp3);
            bubbleDash.IncreaseDash(dashUp3Force);

            ButtonSwitch(dashButton3);

        }
        else
        {
            //can put code in case you can't afford something
        }

    }



    public void ShieldUpgrade1()
    {
        if (playerCurrency.CheckCurrency(shieldUp1))
        {
            playerCurrency.SubtractCurrency(shieldUp1);
            bubbleShield.IncreaseTime(shieldUp1Time);
            ButtonSwitch(shieldButton1, shieldButton2);
            isShieldOn = CheckInteractable(shieldButton1);
            isShield2On = CheckInteractable(shieldButton2);
        }
        else
        {
            //can put code in case you can't afford something
        }
    }

    public void ShieldUpgrade2()
    {

        if (playerCurrency.CheckCurrency(shieldUp2))
        {
            playerCurrency.SubtractCurrency(shieldUp2);
            bubbleShield.IncreaseTime(shieldUp2Time);
            ButtonSwitch(shieldButton2, shieldButton3);
            isShield2On = CheckInteractable(shieldButton2);
            isShield3On = CheckInteractable(shieldButton3);
        }
        else
        {
            //can put code in case you can't afford something
        }
    }

    public void ShieldUpgrade3()
    {
        if (playerCurrency.CheckCurrency(shieldUp3))
        {
            playerCurrency.SubtractCurrency(shieldUp3);
            bubbleShield.IncreaseTime(shieldUp3Time);
            ButtonSwitch(shieldButton3);
            isShield3On = CheckInteractable(shieldButton3);
        }
        else
        {
            //can put code in case you can't afford something
        }

    }

    public void WeaponUpgrade()
    {
        if (playerCurrency.CheckCurrency(weaponUp1))
        {
            playerCurrency.SubtractCurrency(weaponUp1);
            //switch weapon scripts, disable the previous oone and enable the new one
            switchWeapon.Switch();
            //weaponSwitch = true;
            ButtonSwitch(weaponButton1);
            isWeaponOn = CheckInteractable(weaponButton1);
        }
    }


    /*
    private void ButtonSwitch(GameObject button1, GameObject button2, bool isCheck1, bool isCheck2)
    {
        // We need to change the bools in some way 
        Debug.Log("button switch with 4 arg");
        button1.GetComponent<Button>().interactable = false;
        isCheck1 = false;
        button2.GetComponent<Button>().interactable = true;
        isCheck2 = true;

        Debug.Log(isGrappleOn);
        Debug.Log(isGrapple2On);
    }



    //method overloading >: ) 
    private void ButtonSwitch(GameObject button1, bool isCheck1)
    {
        isCheck1 = false;
        button1.GetComponent<Button>().interactable = false;
    }

    */
    //comment this lower button switches out layer 

    private void ButtonSwitch(GameObject button1)
    {
        //isCheck1 = false;
        button1.GetComponent<Button>().interactable = false;
    }
    private void ButtonSwitch(GameObject button1, GameObject button2)
    {
        button1.GetComponent<Button>().interactable = false;
        
        button2.GetComponent<Button>().interactable = true;
       
    }

    /*
    private void ButtonOnCheck(bool buttonCheck, GameObject button1)
    {
        if (buttonCheck)
        {
            button1.GetComponent<Button>().interactable = true;
        }
        else
        {
            button1.GetComponent<Button>().interactable = false;
        }
    }
    */

}
