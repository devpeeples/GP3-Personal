using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    public float interactRange;
    

    private void Update()
    {
        if (Input.GetButtonDown("Interact"))
        {

            Collider[] colliderArray = Physics.OverlapSphere(transform.position, interactRange);
            foreach(Collider collider in colliderArray)
            {
                if (collider.TryGetComponent(out NPCInteractable npcInteractable))
                {
                    

                    gameObject.transform.LookAt(collider.transform);
                    npcInteractable.Interact();
                }
            }
        }
        
        
    }
}
