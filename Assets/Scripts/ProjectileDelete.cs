using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileDelete : MonoBehaviour
{
    public float despawnTime;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(this.gameObject, despawnTime);
    }

    // Update is called once per frame
    void Update()
    {
        
        
    }
}
