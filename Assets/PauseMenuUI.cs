using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuUI : MonoBehaviour
{
    public string mainMenuSceneName;
    public string settingsSceneName;
    public string howToSceneName;

    public void ReturnToMenu()
    {
        AudioController.Instance.PlayGuiEffect(
            AudioController.Instance.Interaction);
        SceneManager.LoadScene(mainMenuSceneName);
    }

    public void OpenSettingsMenu()
    {
        AudioController.Instance.PlayGuiEffect(
            AudioController.Instance.Interaction);
        SceneManager.LoadScene(settingsSceneName, LoadSceneMode.Additive);
    }

    public void OpenHowToMenu()
    {
        AudioController.Instance.PlayGuiEffect(
            AudioController.Instance.Interaction);
        SceneManager.LoadScene(howToSceneName, LoadSceneMode.Additive);
    }
}
