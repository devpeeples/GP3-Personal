using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickup : MonoBehaviour
{
    //audio
    public AudioSource source;
    public AudioClip clip; 

    void OnTriggerEnter(Collider other)
    {
        PlayerHealth health = other.GetComponent<PlayerHealth>();
        //HealthBar SetHealth other.gameObject.GetComponent<HealthBar>();
        PlayerHealth currentHealth = other.GetComponent<PlayerHealth>();
        {
            if (other.gameObject.layer == LayerMask.NameToLayer("Player"))
            {
                if (health != null)
                {
           // public int currentHealth
           // (currentHealth >= 0)
                    {
           //     currentHealth =+ 1;
                        source.Play();
                    }
                }
            }
        }
    }
}
          //      Destroy(gameObject);
      //      }
    //    }
   // }

    // void OnTriggerEnter(Collider other)
    //{
        //check if the one who enters the trigger has the player tag 
        //then check if the player can gather the pickup into a UI Variable 
      //  if (other.gameObject.layer == LayerMask.NameToLayer("Player"))
     //   {
       //     PlayerHealth currentHealth = other.gameObject.GetComponent<PlayerHealth>();
       //     //HealthBar SetHealth other.gameObject.GetComponent<HealthBar>();
        //    //if (currentHealth >= 0)
       //     {

         //       Destroy(gameObject);

       //     }
  
        //    }

     //   }

   // }