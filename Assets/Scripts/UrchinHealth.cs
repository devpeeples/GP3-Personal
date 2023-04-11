using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UrchinHealth : MonoBehaviour
{
    public bool isEnemy;
    public int health;
    //audio
    public AudioSource source;
    public AudioClip clip;

    void Start()
    {
        //health = GetComponent<EnemyHealth>();
    }
    public void TakeDamage(int bulletDamage)
    {
        health = health - bulletDamage;
        if(health == 0)
        {
            if (isEnemy)
            {
                source.Play();
            }

        }
    }
}
