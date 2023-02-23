using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SettingsMenuUI : MonoBehaviour
{
    public string settingsSceneName;
    public static SettingsMenuUI settingsMenuUI { get; private set; }

    [SerializeField] private string mainMenuSceneName;

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
        SceneManager.UnloadSceneAsync(settingsSceneName);
        //SceneManager.LoadScene(mainMenuSceneName);
    }

    public void OnClickSaveBtn()
    {
        // Save changes and return to main menu
        SaveSettings();
        SceneManager.UnloadSceneAsync(settingsSceneName);
        //SceneManager.LoadScene(mainMenuSceneName);
    }

    public void OnClickResetBtn()
    {
        ResetDefaults();
        UpdateSliders();
    }

    private void SaveSettings()
    {
        GameSettings.Instance.Difficulty = difficulty;
        GameSettings.Instance.MasterVolume = masterVolume;
        GameSettings.Instance.EffectsVolume = effectsVolume;
        GameSettings.Instance.MusicVolume = musicVolume;

        GameSettings.Instance.SaveToDisk();
    }

    private void LoadSettings()
    {
        difficulty = GameSettings.Instance.Difficulty;
        masterVolume = GameSettings.Instance.MasterVolume;
        effectsVolume = GameSettings.Instance.EffectsVolume;
        musicVolume = GameSettings.Instance.MusicVolume;
    }

    private void ResetDefaults()
    {
        // Reset temporary values
        difficulty = GameSettings.Instance.DifficultyDefaultVal;
        masterVolume = GameSettings.Instance.MasterVolumeDefaultVal;
        effectsVolume = GameSettings.Instance.EffectsVolumeDefaultVal;
        musicVolume = GameSettings.Instance.MusicVolumeDefaultVal;
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
    }
}
