using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//this script handles enemy health and currency drop

public class EnemyHealth : MonoBehaviour
{
    public bool isEnemy;
    public bool isEmpress;
    public bool isBoss;

    public GameObject HubVortex;
    public GameObject winSceneVortex;
    public float yValueOfFloor;

    public int health = 100;

    private int currencyDrop;
    private Vector3 currencyOffset;
    public AudioSource source;

    /*
    public GameObject currencyObj;
    public GameObject chargeObj;
    public GameObject healthObj;
    public int minCurrency;
    public int maxCurrency;
    */
   
    public Vector3 maxCurrencyOffset;
    public float plane;

    public int maxDrops; 

    public GameObject[] currencyPrefabs;
    public int minCurrencyDrops = 0;
    public int maxCurrencyDrops = 0;

    public GameObject[] chargePrefabs;
    public int minChargeDrops = 0;
    public int maxChargeDrops = 0;

    public GameObject[] healthPrefabs;
    public int minHealthDrops = 0;
    public int maxHealthDrops = 0;

    public void DropCurrency()
    {
        int currencyCount = Random.Range(minCurrencyDrops, maxCurrencyDrops + 1);
        int chargeCount = Random.Range(minChargeDrops, maxChargeDrops + 1);
        int healthCount = Random.Range(minHealthDrops, maxHealthDrops + 1);

        List<GameObject> objectsToDrop = new List<GameObject>();

        // Add currency objects
        for (int i = 0; i < currencyCount; i++)
        {
            if(currencyCount != 0)
            {
                int randomIndex = Random.Range(0, currencyPrefabs.Length);
                objectsToDrop.Add(currencyPrefabs[randomIndex]);
            }
        }

        // Add charge objects
        for (int i = 0; i < chargeCount; i++)
        {
            if(chargeCount != 0)
            {
                int randomIndex = Random.Range(0, chargePrefabs.Length);
                objectsToDrop.Add(chargePrefabs[randomIndex]);
            }
            
        }

        // Add health objects
        for (int i = 0; i < healthCount; i++)
        {
            if(healthCount != 0)
            {
                
                int randomIndex = Random.Range(0, healthPrefabs.Length);
                objectsToDrop.Add(healthPrefabs[randomIndex]);
            }
           
        }

        // Shuffle the objectsToDrop list to randomize the order
        for (int i = 0; i < objectsToDrop.Count; i++)
        {
            Debug.Log("Adding health object");
            GameObject temp = objectsToDrop[i];
            int randomIndex = Random.Range(i, objectsToDrop.Count);
            objectsToDrop[i] = objectsToDrop[randomIndex];
            objectsToDrop[randomIndex] = temp;
        }

        // Drop the objects
        for (int i = 0; i < maxDrops; i++)
        {
            Debug.Log("For max drops");
            CurrencyOffset();
            if( objectsToDrop.Count != 0)
            {
                Instantiate(objectsToDrop[i], new Vector3(transform.position.x, plane, transform.position.z) + currencyOffset, Quaternion.identity);
            }
            
        }
    }

    public void TakeDamage(int bulletDamage)
    {
        if(source != null)
        {
            source.Play();
        }
        
        health = health - bulletDamage;
        if(health <= 0)
        {
            if (isEnemy)
            {
                Debug.Log("Enemy Died");
                DropCurrency();
            }

            if (isBoss)
            {
                //load hub
                HubVortex.SetActive(true);
                //SceneManager.LoadScene("WinScreen");
            }
            if (isEmpress)
            {
                winSceneVortex.SetActive(true);
            }

            //delete the enemy from the enemy list 
            // Destroy(gameObject);
            gameObject.SetActive(false);
        }
    }


    //here we instatiate a random int of currency 
    /*
    private void CurrencyDrop()
    {
        currencyDrop = Random.Range(minCurrency, maxCurrency);

        

        for (int i = 0; i <= currencyDrop; i++)
        {
            CurrencyOffset();
            Instantiate(currencyObj, new Vector3(transform.position.x, this.gameObject.transform.position.y, transform.position.z) + currencyOffset, transform.rotation);
        }
        

    }
    */





    private void CurrencyOffset()
    {
        currencyOffset = new Vector3(Random.Range(0, maxCurrencyOffset.x), Random.Range(0, maxCurrencyOffset.y), Random.Range(0, maxCurrencyOffset.z));
    }

    public void KillEnemy()
    {
        DropCurrency();
        Destroy(gameObject);
    }

}
