using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MetricsMenuUI : MonoBehaviour
{

    public string mainMenuSceneName;
    
    public void ReturnToMenu()
    {
        AudioController.Instance.PlayGuiEffect(
            AudioController.Instance.Interaction);
        SceneManager.LoadScene(mainMenuSceneName);
    }
}
