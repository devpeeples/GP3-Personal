using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//this script handles enemy health and currency drop

public class EnemyHealth : MonoBehaviour
{
    public int minCurrency;
    public int maxCurrency;
    public bool isEnemy;

    public bool isBoss;
    public GameObject currencyObj;
    public Vector3 maxCurrencyOffset;
    public float plane;

    public int health = 100;

    private int currencyDrop;
    private Vector3 currencyOffset;

    public void TakeDamage(int bulletDamage)
    {
        health = health - bulletDamage;
        if(health <= 0)
        {
            if (isEnemy)
            {
                CurrencyDrop();
            }

            if (isBoss)
            {
                SceneManager.LoadScene("WinScreen");
            }

            //delete the enemy from the enemy list 
            // Destroy(gameObject);
            gameObject.SetActive(false);
        }
    }


    //here we instatiate a random int of currency 
    private void CurrencyDrop()
    {
        currencyDrop = Random.Range(minCurrency, maxCurrency);

        

        for (int i = 0; i <= currencyDrop; i++)
        {
            CurrencyOffset();
            Instantiate(currencyObj, new Vector3(transform.position.x, plane, transform.position.z) + currencyOffset, transform.rotation);
        }
        

    }
    private void CurrencyOffset()
    {
        currencyOffset = new Vector3(Random.Range(0, maxCurrencyOffset.x), Random.Range(0, maxCurrencyOffset.y), Random.Range(0, maxCurrencyOffset.z));
    }

}
