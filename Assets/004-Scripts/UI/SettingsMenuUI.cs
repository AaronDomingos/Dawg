using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SettingsMenuUI : MonoBehaviour
{
    public static SettingsMenuUI settingsMenuUI { get; private set; }

    [SerializeField] private string mainMenuSceneName;

    [SerializeField] private AudioClip clickSound;

    // UI elements
    [SerializeField] private Slider difficultySlider;
    [SerializeField] private Slider masterVolumeSlider;
    [SerializeField] private Slider effectsVolumeSlider;
    [SerializeField] private Slider musicVolumeSlider;

    // Temporary (unsaved) settings values
    private float difficulty;
    private float masterVolume;
    private float effectsVolume;
    private float musicVolume;

    public Slider DifficultySlider { get => difficultySlider; set => difficultySlider = value; }
    public Slider MasterVolumeSlider { get => masterVolumeSlider; set => masterVolumeSlider = value; }
    public Slider EffectsVolumeSlider { get => effectsVolumeSlider; set => effectsVolumeSlider = value; }
    public Slider MusicVolumeSlider { get => musicVolumeSlider; set => musicVolumeSlider = value; }

    public void OnDifficultyValueChanged()
    {
        difficulty = difficultySlider.value;
    }

    public void OnMasterVolumeValueChanged()
    {
        masterVolume = masterVolumeSlider.value;
    }

    public void OnEffectsVolumeValueChanged()
    {
        effectsVolume = effectsVolumeSlider.value;
    }

    public void OnMusicVolumeValueChanged()
    {
        musicVolume = musicVolumeSlider.value;
    }

    public void OnClickBackBtn()
    {
        // Disregard changes and return to main menu
        SceneManager.LoadScene(mainMenuSceneName);
        AudioController.singleton.PlayGuiEffect(clickSound);
    }

    public void OnClickSaveBtn()
    {
        // Save changes and return to main menu
        SaveSettings();
        SceneManager.LoadScene(mainMenuSceneName);
        AudioController.singleton.PlayGuiEffect(clickSound);
    }

    public void OnClickResetBtn()
    {
        ResetDefaults();
        UpdateSliders();
        AudioController.singleton.PlayGuiEffect(clickSound);
    }

    private void SaveSettings()
    {
        GameSettings.singleton.Difficulty = difficulty;
        GameSettings.singleton.MasterVolume = masterVolume;
        GameSettings.singleton.EffectsVolume = effectsVolume;
        GameSettings.singleton.MusicVolume = musicVolume;

        GameSettings.singleton.SaveToDisk();
    }

    private void LoadSettings()
    {
        difficulty = GameSettings.singleton.Difficulty;
        masterVolume = GameSettings.singleton.MasterVolume;
        effectsVolume = GameSettings.singleton.EffectsVolume;
        musicVolume = GameSettings.singleton.MusicVolume;
    }

    private void ResetDefaults()
    {
        // Reset temporary values
        difficulty = GameSettings.singleton.DifficultyDefaultVal;
        masterVolume = GameSettings.singleton.MasterVolumeDefaultVal;
        effectsVolume = GameSettings.singleton.EffectsVolumeDefaultVal;
        musicVolume = GameSettings.singleton.MusicVolumeDefaultVal;
    }

    private void UpdateSliders()
    {
        difficultySlider.value = difficulty;
        masterVolumeSlider.value = masterVolume;
        effectsVolumeSlider.value = effectsVolume;
        musicVolumeSlider.value = musicVolume;
    }

    private void Awake()
    {
        /* On startup (upon entering the settings scene), load GameSettings values into temporary settings,
         * and update the sliders to reflect this change */
        LoadSettings();
        UpdateSliders();

        // Due to a bug with the GUI elements, slider min values must be set here...
        masterVolumeSlider.minValue = 0.0001f;
        effectsVolumeSlider.minValue = 0.0001f;
        musicVolumeSlider.minValue = 0.0001f;
    }
}
