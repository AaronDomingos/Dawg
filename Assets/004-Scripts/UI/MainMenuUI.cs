using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuUI : MonoBehaviour
{
    [SerializeField] private string gameSceneName;
    [SerializeField] private string settingsSceneName;
    [SerializeField] private string howToSceneName;

    private void Start()
    {
        AudioController.Instance.PlayMusicClip(
            AudioController.Instance.Background1);
    }

    public void OnClickPlayBtn()
    {
        AudioController.Instance.PlayGuiEffect(
            AudioController.Instance.Interaction);
        SceneManager.LoadScene(gameSceneName);
    }

    public void OnClickSettingsBtn()
    {
        AudioController.Instance.PlayGuiEffect(
            AudioController.Instance.Interaction);
        SceneManager.LoadScene(settingsSceneName, LoadSceneMode.Additive);
    }

    public void OnClickHowToButn()
    {
        AudioController.Instance.PlayGuiEffect(
            AudioController.Instance.Interaction);
        SceneManager.LoadScene(howToSceneName, LoadSceneMode.Additive);
    }

    public void OnClickCloseGame()
    {
        Application.Quit();
    }
}
