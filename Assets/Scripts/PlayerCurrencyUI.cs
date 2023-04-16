using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerCurrencyUI : MonoBehaviour
{
    public GameObject CurrencyUI;
    public int totalCurrency;
    public AudioManager am;


    public void Update()
    {
        CurrencyUI.GetComponent<Text>().text = totalCurrency.ToString();
    }
    public void addCurrency(int currency)
    {
        am.Play("Pickup");

        totalCurrency = totalCurrency + currency;
        
    }
    public void SubtractCurrency(int currency)
    {
        totalCurrency = totalCurrency - currency;
    }
    public void RobPlayer()
    {
        totalCurrency = 0;
    }

    public bool CheckCurrency(int amount)
    {
        if (amount <= totalCurrency)
        {
            return true;
        }
        else
        {
            return false;
        }
    }




}
