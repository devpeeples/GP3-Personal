using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioUtility : MonoBehaviour
{
    public float masterVolume;
    public static AudioSource audioSource;
    public static Dictionary<string, AudioClip> tracks = new Dictionary<string, AudioClip>();

    public static void SetAudioSource(AudioSource source)
    {
        audioSource = source;
    }
    public static void AddTrack(string trackTitle, AudioClip trackClip)
    {
        tracks.Add(trackTitle, trackClip);
    }

        public static void PlayTrack(string trackTitle)
        {
            if(tracks.ContainsKey(trackTitle))
            {
                audioSource.clip = tracks[trackTitle];
                audioSource.Play();
                //s.source.volume = masterVolume;
            }
            else
            {
                Debug.Log($"Track: {trackTitle} does not exist");
            }
        }
}
