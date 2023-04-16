using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchWeapon : MonoBehaviour
{
    private RBPlayerShooting playerShooting;
    private PlayerShooting2 playerShooting2;
    public bool isSwitched; 
    // Start is called before the first frame update
    private void Awake()
    {
        
        playerShooting = this.gameObject.GetComponent<RBPlayerShooting>();
        playerShooting2 = this.gameObject.GetComponent<PlayerShooting2>();
        BoolToAction();



    }
    public void Switch()
    {
        playerShooting.enabled = false;
        playerShooting2.enabled = true;
        isSwitched = true; 


    }
    public void BoolToAction()
    {
        if (isSwitched)
        {
            playerShooting.enabled = false;
            playerShooting2.enabled = true;
        }
        else
        {
            //Debug.Log(playerShooting);
            playerShooting.enabled = true;
            playerShooting2.enabled = false;
        }
    }

}
