using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuUI : MonoBehaviour
{
    [SerializeField] private string gameSceneName;
    [SerializeField] private string settingsSceneName;

    public void OnClickPlayBtn()
    {
        SceneManager.LoadScene(gameSceneName);
    }

    public void OnClickSettingsBtn()
    {
        SceneManager.LoadScene(settingsSceneName);
    }
}
