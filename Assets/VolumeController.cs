using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class VolumeController : MonoBehaviour
{
    [SerializeField] private AudioMixer mixer;
    [SerializeField] private Slider masterSlider;
    [SerializeField] private Slider musicSlider;
    [SerializeField] private Slider sfxSlider;

    private void Start()
    {
        if (PlayerPrefs.HasKey("MasterVolume"))
        {
            LoadVolume("MasterVolume");
        }
        else
        {
            SetMasterVolume();
            SetMusicVolume();
            SetSFXVolume();
        }
    }

    public void SetMasterVolume()
    {
        float volume = masterSlider.value;
        mixer.SetFloat("Master", Mathf.Log10(volume)*20);
        PlayerPrefs.SetFloat("MasterVolume", volume);
    }
    public void SetMusicVolume()
    {
        float volume = musicSlider.value;
        mixer.SetFloat("Music", Mathf.Log10(volume)*20);
        PlayerPrefs.SetFloat("MusicVolume", volume);
    }
    public void SetSFXVolume()
    {
        float volume = sfxSlider.value;
        mixer.SetFloat("SFX", Mathf.Log10(volume)*20);
        PlayerPrefs.SetFloat("SFXVolume", volume);
    }
    private void LoadVolume(string v)
    {
        masterSlider.value=PlayerPrefs.GetFloat("MasterVolume");
        SetMasterVolume();

        musicSlider.value=PlayerPrefs.GetFloat("MusicVolume");
        SetMusicVolume();

        sfxSlider.value=PlayerPrefs.GetFloat("SFXVolume");
        SetSFXVolume();
    }
}

