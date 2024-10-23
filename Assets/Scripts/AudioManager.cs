using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{

    /** References **/
    [SerializeField] private AudioMixer mixer;
    [SerializeField] private AudioClip[] music;
    [SerializeField] private AudioClip[] ambient;
    [SerializeField] private AudioClip[] sfx;

    [SerializeField] private AudioSource musicSource;
    [SerializeField] private AudioSource ambientSource;
    [SerializeField] private AudioSource sfxSource;

    void Start()
    {
        mixer.SetFloat("MasterVolume", PlayerPrefs.GetFloat("MasterVolume", 0));
        mixer.SetFloat("MusicVolume", PlayerPrefs.GetFloat("MusicVolume", 0));
        mixer.SetFloat("SFXVolume", PlayerPrefs.GetFloat("SFXVolume", 0));
        mixer.SetFloat("AmbienceVolume", PlayerPrefs.GetFloat("AmbienceVolume", 0));
    }

    public void ChangeMusic(int id)
    {
        musicSource.clip = music[id];
        musicSource.Play();
    }

    public void ChangeAmbient(int id)
    {
        ambientSource.clip = ambient[id];
        ambientSource.Play();
    }

    public void StopMusic()
    {
        musicSource.Stop();
    }

    public void StopAmbient()
    {
        ambientSource.Stop();
    }

    public void PlayMusic()
    {
        musicSource.Play();
    }

    public void PlayAmbient()
    {
        ambientSource.Play();
    }

    public void StopSFX()
    {
        sfxSource.Stop();
    }

    public void StopAll()
    {
        StopMusic();
        StopAmbient();
        StopSFX();
    }

    public void PlaySFX(int id)
    {
        sfxSource.PlayOneShot(sfx[id]);
    }
}
