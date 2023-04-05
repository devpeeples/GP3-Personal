using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    public GameObject[] enemyArray; 


    private GameObject i; 
   
    //on start open the list and record the game objects i



    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            foreach (GameObject i in enemyArray)
            {
                
                    
                if (!i.activeSelf)
                {
                    i.SetActive(true);
                }

              
            }
            
        }
    }  
}
