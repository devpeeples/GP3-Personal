using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDespawn : MonoBehaviour
{
    
    public GameObject[] enemyArray; 


    private int i ; 
   


   


    void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            for(i = 0; i < enemyArray.Length; i++)
            {
                if(!enemyArray[i] == null)
                {
                    enemyArray[i].SetActive(false);
                }
                
            }
            
        }
    }   

    
}