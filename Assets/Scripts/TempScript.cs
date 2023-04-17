using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TempScript : MonoBehaviour
{
    // Start is called before the first frame update


    // Update is called once per frame
    void Update()
    {
        if(Input.GetAxis("Shoot") == 1)
        {
            Debug.Log(Input.GetAxis("Shoot"));

        }

        Debug.Log(Input.GetAxis("Shoot"));
        //Debug.Log(Input.GetAxis("JoyStickGrapple"));
    }
}