using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuUI : MonoBehaviour
{
    [SerializeField] private string gameSceneName;
    [SerializeField] private string settingsSceneName;
    [SerializeField] private AudioClip clickSound;

    public void OnClickPlayBtn()
    {
        SceneManager.LoadScene(gameSceneName);
        AudioController.singleton.PlayGuiEffect(clickSound);
    }

    public void OnClickSettingsBtn()
    {
        SceneManager.LoadScene(settingsSceneName);
        AudioController.singleton.PlayGuiEffect(clickSound);
    }
}
