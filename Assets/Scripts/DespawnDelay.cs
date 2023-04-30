using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DespawnDelay : MonoBehaviour
{
    public float despawnDelay; 
   void OnEnable()
    {
        Invoke("DestroyObj", despawnDelay);
    }
    void DestroyObj()
    {
        Destroy(gameObject);
    }
}
