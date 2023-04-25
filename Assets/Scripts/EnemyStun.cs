using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStun : MonoBehaviour
{
    //this is a private script ref 
    private MeleeFollow meleeFollow;
    //public float stunTime;

    //make particle a prefab and then add it using this- make sure particle effect is child of the enemy
    public ParticleSystem particleHit;


    public void Stun(float stunTime)
    {


        MeleeFollow meleeFollow = GetComponent<MeleeFollow>();

        //if the enemy has the melee follow script, tell them to stop moving 
        if (meleeFollow != null)
        {
            Debug.Log(stunTime);
            meleeFollow.StunOn();
            if (particleHit != null)
            {
                particleHit.gameObject.SetActive(true);
                particleHit.loop = true;
                particleHit.Play();
            }
            Invoke("UnStun", stunTime);
        }
        else
        {
            Debug.Log("null");
        }

        //here you could put an else statement for the enemies that don't move

    }


    /*
    public void StunCollider(float seperateStunTime)
    {

        MeleeFollow meleeFollow = GetComponent<MeleeFollow>();
        
        //if the enemy has the melee follow script, tell them to stop moving 
        if (meleeFollow != null)
        {
            Debug.Log("s");
            meleeFollow.StunOn();
            Invoke("UnStun", seperateStunTime);
        }
        else
        {
            Debug.Log("null");
        }
        //here you could put an else statement for the enemies that don't move

    }
    */

    private void UnStun()
    {
        MeleeFollow meleeFollow = GetComponent<MeleeFollow>();
        if (particleHit != null)
        {
            particleHit.gameObject.SetActive(false);
            
        }
        if (meleeFollow != null)
        {
            meleeFollow.StunOff();
        }
    }
}

