using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialPopups : MonoBehaviour
{
    public GameObject Popup;
    private void OnTriggerEnter(Collider other)
    {
        //checks if the collided object has a player tag, I couldnt do mask tag because that returns some number value and it's weird
        if (other.gameObject.tag == "Player")
        {
            Popup.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Popup.SetActive(false);
        }
    }
}
