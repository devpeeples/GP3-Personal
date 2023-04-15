using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCInteractable : MonoBehaviour
{
    public bool simple;
    public bool complex;

    public GameObject simpleObj;
    public GameObject complexObj;



    public void Interact()
    {
        if (simple)
        {
            simpleObj.SetActive(true);
        }
        if (complex)
        {
            if (!complexObj.GetComponent<UINext>().isShowingNext)
            {
                complexObj.SetActive(true);
            }
            
        }

   
    }





}
