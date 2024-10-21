using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using System;

public class OptionsMenu : MonoBehaviour
{

    /** References **/
    [SerializeField] private Toggle fullscreenToggle;
    [SerializeField] private Toggle vsyncToggle;
    [SerializeField] private TMP_Dropdown resolutionDropdown;
    [SerializeField] private AudioMixer mixer;
    [SerializeField] private TMP_Text masterVolumeText;
    [SerializeField] private TMP_Text sfxVolumeText;
    [SerializeField] private TMP_Text musicVolumeText;
    [SerializeField] private TMP_Text ambienceVolumeText;
    [SerializeField] private Slider masterVolumeSlider;
    [SerializeField] private Slider musicVolumeSlider;
    [SerializeField] private Slider sfxVolumeSlider;
    [SerializeField] private Slider ambienceVolumeSlider;


    /** Variables **/
    private Resolution[] resolutions;

    void Awake()
    {
        fullscreenToggle.isOn = Screen.fullScreen;
        vsyncToggle.isOn = QualitySettings.vSyncCount == 1;
        GatherAvailableResolutions();
    }

    void Start()
    {
        mixer.GetFloat("MasterVolume", out float vol);
        masterVolumeSlider.value = vol;
        masterVolumeText.text = Mathf.RoundToInt((masterVolumeSlider.value + 80)) + "%";

        mixer.GetFloat("MusicVolume", out vol);
        musicVolumeSlider.value = vol;
        musicVolumeText.text = Mathf.RoundToInt((musicVolumeSlider.value + 80)) + "%";

        mixer.GetFloat("SFXVolume", out vol);
        sfxVolumeSlider.value = vol;
        sfxVolumeText.text = Mathf.RoundToInt((sfxVolumeSlider.value + 80)) + "%";

        mixer.GetFloat("AmbienceVolume", out vol);
        ambienceVolumeSlider.value = vol;
        ambienceVolumeText.text = Mathf.RoundToInt((ambienceVolumeSlider.value + 80)) + "%";
    }

    private void GatherAvailableResolutions()
    {
        resolutionDropdown.ClearOptions();
        List<string> options = new List<string>();
        resolutions = Screen.resolutions;
        int currentResolutionIndex = 0;
        for (int i = 0; i < resolutions.Length; i++)
        {
            Resolution resolution = resolutions[i];
            string option = resolution.width + " x " + resolution.height;
            options.Add(option);
            if (resolution.width == Screen.width && resolution.height == Screen.height)
            {
                currentResolutionIndex = i;
            }
        }
        resolutionDropdown.AddOptions(options);
        resolutionDropdown.value = currentResolutionIndex;
        resolutionDropdown.RefreshShownValue();
    }

    public void ApplyGraphics()
    {
        QualitySettings.vSyncCount = vsyncToggle.isOn ? 1 : 0;
        Screen.SetResolution(resolutions[resolutionDropdown.value].width, resolutions[resolutionDropdown.value].height, Screen.fullScreen);
    }


    public void SetMasterVolume()
    {
        mixer.SetFloat("MasterVolume", masterVolumeSlider.value);
        masterVolumeText.text = Mathf.RoundToInt((masterVolumeSlider.value + 80))+ "%";
        PlayerPrefs.SetFloat("MasterVolume", masterVolumeSlider.value);
    }

    public void SetMusicVolume()
    {
        mixer.SetFloat("MusicVolume", musicVolumeSlider.value);
        musicVolumeText.text = Mathf.RoundToInt((musicVolumeSlider.value + 80)) + "%";
        PlayerPrefs.SetFloat("MusicVolume", musicVolumeSlider.value);
    }

    public void SetSFXVolume()
    {
        mixer.SetFloat("SFXVolume", sfxVolumeSlider.value);
        sfxVolumeText.text = Mathf.RoundToInt((sfxVolumeSlider.value + 80)) + "%";
        PlayerPrefs.SetFloat("SFXVolume", sfxVolumeSlider.value);
    }

    public void SetAmbienceVolume()
    {
        mixer.SetFloat("AmbienceVolume", ambienceVolumeSlider.value);
        ambienceVolumeText.text = Mathf.RoundToInt((ambienceVolumeSlider.value + 80)) + "%";
        PlayerPrefs.SetFloat("AmbienceVolume", ambienceVolumeSlider.value);
    }

}
