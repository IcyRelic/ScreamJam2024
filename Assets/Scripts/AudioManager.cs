using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{

    /** References **/
    [SerializeField] private AudioMixer mixer;

    void Start()
    {
        mixer.SetFloat("MasterVolume", PlayerPrefs.GetFloat("MasterVolume", 0));
        mixer.SetFloat("MusicVolume", PlayerPrefs.GetFloat("MusicVolume", 0));
        mixer.SetFloat("SFXVolume", PlayerPrefs.GetFloat("SFXVolume", 0));
        mixer.SetFloat("AmbienceVolume", PlayerPrefs.GetFloat("AmbienceVolume", 0));
    }

}
