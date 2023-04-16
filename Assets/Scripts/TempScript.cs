using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TempScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        AudioListener[] listeners = FindObjectsOfType<AudioListener>();
        foreach (AudioListener listener in listeners)
        {
            Debug.Log("AudioListener found on GameObject: " + listener.gameObject.name);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}