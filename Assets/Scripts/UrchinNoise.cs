using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UrchinNoise : MonoBehaviour
{
    //public AudioManager am;
    public GameObject audioManagerObject;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("PLaySound", 3.0f, 3.0f);
    }

    // Update is called once per frame
    void Update()
    {
        //am.Play("Urchin");
        //audioManagerObject.GetComponent<AudioManager>().Play("Urchin");
    }
    void PlaySound(){

         audioManagerObject.GetComponent<AudioManager>().Play("Urchin");
    }
}
