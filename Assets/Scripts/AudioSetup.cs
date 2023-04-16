using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioSetup : MonoBehaviour
{
    
   [SerializeField] private AudioTrack[] tracks;
   [SerializeField] private AudioSource mainSource;
   public string trackname;
   
   void Start()
   {
        AudioUtility.SetAudioSource(mainSource);

        foreach (var item in tracks)
        {
            AudioUtility.AddTrack(item.trackTitle, item.trackClip);
        }

        AudioUtility.PlayTrack(trackname);
   }
}
