using System.Collections;
using System.Collections.Generic;
using UnityEngine;



[System.Serializable]
public class ShopData 
{
    public int grapple1button;
    public int grapple2button;
    public int grapple3button;


    public int coral1button;
    public int coral2button;
    public int coral3button;

    public int shield1button;
    public int shield2button;
    public int shield3button;


    public int dash1button;
    public int dash2button;
    public int dash3button;

    public int weapon1button;


    public ShopData(ShopButtons shopButtons)
    {
        
        grapple1button =  boolToInt(shopButtons.isGrappleOn);
        grapple2button = boolToInt(shopButtons.isGrapple2On);
        grapple3button = boolToInt(shopButtons.isGrapple3On);

        coral1button = boolToInt(shopButtons.isCoralOn);
        coral2button = boolToInt(shopButtons.isCoral2On);
        coral3button = boolToInt(shopButtons.isCoral3On);


        shield1button = boolToInt(shopButtons.isShieldOn);
        shield2button = boolToInt(shopButtons.isShield2On);
        shield3button = boolToInt(shopButtons.isShield3On);

        
        dash1button = boolToInt(shopButtons.isDashOn);
        dash2button = boolToInt(shopButtons.isDash2On);
        dash3button = boolToInt(shopButtons.isDash3On);

        weapon1button = boolToInt(shopButtons.isWeaponOn);

        //debug checking what data is going through
        Debug.Log(grapple1button);
        Debug.Log(grapple2button);
        Debug.Log(grapple3button);

    }


    private int boolToInt(bool ischecking)
    {
       
        if (ischecking == true)
        {
            
            return 1; 


        }
        else
        {
            return 0; 
        }

    }


}
