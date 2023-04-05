using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHit : MonoBehaviour
{
    //this public int can be changed for how much damage you want the enemy collision to do 
    public int damage;
    
 

    void OnCollisionEnter(Collision collision)
    {
        //checks if the collided object has a player tag, I couldnt do mask tag because that returns some number value and it's weird
        if (collision.collider.gameObject.transform.tag == "Player")
        {

           
            PlayerHealth playerHealth = collision.gameObject.GetComponent<PlayerHealth>();
            //checks if the player has the player health script 
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(damage);
            }
        }
        
   
    }
}
