using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UITimer : MonoBehaviour
{
    public float time; 

    private void OnEnable()
    {
        Invoke("NotActive", time);

        
    }

    private void NotActive()
    {
        this.gameObject.SetActive(false);
    }




}
