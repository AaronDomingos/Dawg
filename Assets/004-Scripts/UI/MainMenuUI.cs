using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuUI : MonoBehaviour
{
    [SerializeField] private string gameSceneName;
    [SerializeField] private string settingsSceneName;

    private void Start()
    {
        AudioController.singleton.PlayMusicClip(
            AudioController.singleton.Background1);
    }

    public void OnClickPlayBtn()
    {
        AudioController.singleton.PlayGuiEffect(
            AudioController.singleton.Interaction);
        SceneManager.LoadScene(gameSceneName);
    }

    public void OnClickSettingsBtn()
    {
        AudioController.singleton.PlayGuiEffect(
            AudioController.singleton.Interaction);
        SceneManager.LoadScene(settingsSceneName);
    }
}
