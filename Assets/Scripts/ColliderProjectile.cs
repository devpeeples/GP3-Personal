using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderProjectile : MonoBehaviour
{
    public int bulletDamage;

    private void OnCollisionEnter(Collision other)
    {
        if (other.transform.tag == "Enemy")
        {
            EnemyHealth enemyHealth = other.transform.GetComponent<EnemyHealth>();
            //Destroy(collision.gameObject);
            enemyHealth.TakeDamage(bulletDamage);
        }
    }
}
