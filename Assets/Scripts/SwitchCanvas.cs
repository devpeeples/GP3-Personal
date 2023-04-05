using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class SwitchCanvas : MonoBehaviour
{
    // This script allows for the Main Menu UI to utilize keyboard and gamepad inputs between different canvases.
    public GameObject offCanvas; // For canvases that are turned off (ex: controls and credits menu's).
    public GameObject onCanvas; // For the main menu canvas that is turned on.
    public GameObject firstObject; // Must be attached to the button in the OffCanvas.
    
    public void Switch()
    {
        offCanvas.SetActive (true);
        onCanvas.SetActive (false);
        GameObject.Find("EventSystem").GetComponent<EventSystem> ().SetSelectedGameObject (firstObject, null);
    }
}
