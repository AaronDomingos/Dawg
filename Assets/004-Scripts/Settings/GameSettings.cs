using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

/* This class stores settings data and calls the appropriate method(s) when a setting value is changed */
public class GameSettings : MonoBehaviour
{
    public static GameSettings singleton { get; private set; }

    private float difficulty;
    private float masterVolume;
    private float effectsVolume;
    private float musicVolume;

    // Default values (can't use constructor defaults because it's a singleton...)
    [SerializeField] private float difficultyDefaultVal = 0.2f;
    [SerializeField] private float masterVolumeDefaultVal = 0.5f;
    [SerializeField] private float effectsVolumeDefaultVal = 0.5f;
    [SerializeField] private float musicVolumeDefaultVal = 0.5f;

    [SerializeField] private AudioMixer audioMixer;

    public float DifficultyDefaultVal { get => difficultyDefaultVal; set => difficultyDefaultVal = value; }
    public float MasterVolumeDefaultVal { get => masterVolumeDefaultVal; set => masterVolumeDefaultVal = value; }
    public float EffectsVolumeDefaultVal { get => effectsVolumeDefaultVal; set => effectsVolumeDefaultVal = value; }
    public float MusicVolumeDefaultVal { get => musicVolumeDefaultVal; set => musicVolumeDefaultVal = value; }

    /* Getters and setters should run GameSettingsController logic and update the GUI */
    public float Difficulty
    {
        get => difficulty;

        set
        {
            // To-do: implement difficulty system
            difficulty = value;
        }
    }

    public float MasterVolume {
        get => masterVolume;

        set
        {
            masterVolume = value;
            AudioController.singleton.ChangeVolume("MasterVolume", value);
        }
    }


    public float EffectsVolume { get => effectsVolume;
        set
        {
            effectsVolume = value;
            AudioController.singleton.ChangeVolume("EffectsVolume", value);
        }
    }

    public float MusicVolume { get => musicVolume;
        set
        {
            musicVolume = value;
            AudioController.singleton.ChangeVolume("MusicVolume", value);
        }
    }

    private void Awake()
    {
        // If another instance exists and isn't this object...
        if(singleton != null && singleton != this)
        {
            Destroy(this);
        } else
        {
            singleton = this;
        }

        DontDestroyOnLoad(this.gameObject);

        // On startup, load all preferences from disk to GameSettings manager
        LoadFromDisk();
    }

    public void SaveToDisk()
    {
        PlayerPrefs.SetFloat("Difficulty", difficulty);
        PlayerPrefs.SetFloat("MasterVolume", masterVolume);
        PlayerPrefs.SetFloat("EffectsVolume", effectsVolume);
        PlayerPrefs.SetFloat("MusicVolume", musicVolume);
    }

    public void LoadFromDisk()
    {
        // If setting already exists on disk...
        if (PlayerPrefs.HasKey("Difficulty"))
        {
            // Load it into the game
            difficulty = PlayerPrefs.GetFloat("Difficulty");
        }
        else
        {
            // Initialize default value
            PlayerPrefs.SetFloat("Difficulty", GameSettings.singleton.DifficultyDefaultVal);
            // And load it into the game
            difficulty = PlayerPrefs.GetFloat("Difficulty");
        }

        // If setting already exists on disk...
        if (PlayerPrefs.HasKey("MasterVolume"))
        {
            // Load it into the game
            masterVolume = PlayerPrefs.GetFloat("MasterVolume");
        }
        else
        {
            // Initialize default value
            PlayerPrefs.SetFloat("MasterVolume", GameSettings.singleton.MasterVolumeDefaultVal);
            // And load it into the game
            masterVolume = PlayerPrefs.GetFloat("MasterVolume");
        }

        // If setting already exists on disk...
        if (PlayerPrefs.HasKey("EffectsVolume"))
        {
            // Load it into the game
            effectsVolume = PlayerPrefs.GetFloat("EffectsVolume");
        }
        else
        {
            // Initialize default value
            PlayerPrefs.SetFloat("EffectsVolume", GameSettings.singleton.EffectsVolumeDefaultVal);
            // And load it into the game
            effectsVolume = PlayerPrefs.GetFloat("EffectsVolume");
        }

        // If setting already exists on disk...
        if (PlayerPrefs.HasKey("MusicVolume"))
        {
            // Load it into the game
            musicVolume = PlayerPrefs.GetFloat("MusicVolume");
        }
        else
        {
            // Initialize default value
            PlayerPrefs.SetFloat("MusicVolume", GameSettings.singleton.MusicVolumeDefaultVal);
            // And load it into the game
            musicVolume = PlayerPrefs.GetFloat("MusicVolume");
        }
    }
}
