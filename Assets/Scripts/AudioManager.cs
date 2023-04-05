using UnityEngine.Audio;
using System;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public float masterVolume;
    public Sound[] sounds;
    void Awake()
    {
        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.loop = s.loop;
        }
    }

    void Start()
    {
        Play("LevelTheme");
    }

    public void Play(string name)
    {
        Sound s= Array.Find(sounds, sound => sound.name == name);
        s.source.Play();
        s.source.volume = masterVolume;
        s.source.pitch = s.pitch;
    }
    public void Stop(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        s.source.Stop();
    }
}
