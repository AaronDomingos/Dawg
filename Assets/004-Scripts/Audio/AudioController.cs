using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioController : MonoBehaviour
{
    public static AudioController singleton { get; private set; }

    [SerializeField] private AudioSource guiEffectsSource;
    [SerializeField] private AudioSource gameEffectsSource;
    [SerializeField] private AudioSource playerEffectsSource;
    [SerializeField] private AudioSource musicSource;

    [SerializeField] private AudioMixer mixer;

    public AudioClip Interaction;
    
    
    
    
    
    
    

    public void PlayGuiEffect(AudioClip audioClip)
    {
        guiEffectsSource.clip = audioClip;
        guiEffectsSource.Play();
    }

    public void PlayGameEffect(AudioClip audioClip)
    {
        gameEffectsSource.clip = audioClip;
        gameEffectsSource.Play();
    }

    public void PlayPlayerEffect(AudioClip audioClip)
    {
        playerEffectsSource.clip = audioClip;
        playerEffectsSource.Play();
    }

    private void Awake()
    {
        if(singleton != null && singleton != this)
        {
            Destroy(this);
        } else
        {
            singleton = this;
        }

        DontDestroyOnLoad(this.gameObject);
        DontDestroyOnLoad(guiEffectsSource);
        DontDestroyOnLoad(gameEffectsSource);
        DontDestroyOnLoad(playerEffectsSource);
        DontDestroyOnLoad(musicSource);
    }

    public void ChangeVolume(string channel, float value)
    {
        mixer.SetFloat(channel, Mathf.Log10(value) * 20);
    }
}