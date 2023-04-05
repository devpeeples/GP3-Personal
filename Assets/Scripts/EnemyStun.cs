using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStun : MonoBehaviour
{
    //this is a private script ref 
    private MeleeFollow meleeFollow = null;


    public void Stun()
    {
        
        MeleeFollow meleeFollow = GetComponent<MeleeFollow>();

        //if the enemy has the melee follow script, tell them to stop moving 
        if (meleeFollow != null)
        {

            meleeFollow.StunOn();
            Invoke("UnStun", 3.0f);
        }

        //here you could put an else statement for the enemies that don't move
       
    }

    private void UnStun()
    {
        MeleeFollow meleeFollow = GetComponent<MeleeFollow>();
        
        if (meleeFollow != null)
        {
            meleeFollow.StunOff();
        }
    }
}

