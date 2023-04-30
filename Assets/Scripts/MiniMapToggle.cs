using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniMapToggle : MonoBehaviour
{
    public GameObject minimapParent;
    private bool isOn; 

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("MapToggle"))
        {
            if (!isOn)
            {
                Debug.Log("Set active true");
                minimapParent.SetActive(true);
                isOn = true; 
            }

            else if (isOn)
            {
                Debug.Log("Set active false");
                minimapParent.SetActive(false);
                isOn = false; 
            }
        }
        
    }
}
