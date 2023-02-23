using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HowToController : MonoBehaviour
{
    public string HowToSceneName;
    
    
    public List<GameObject> TabPanels = new List<GameObject>();
    
    private void OnEnable()
    {
        DisableAllTabsExcept(0);
    }

    public void ExitHowToMenu()
    {
        //gameObject.SetActive(false);
        SceneManager.UnloadSceneAsync(HowToSceneName);
    }

    public void DisableAllTabsExcept(int index)
    {
        //Debug.Log("Click");
        DisableAllTabs();
        EnableTab(index);
    }

    public void DisableAllTabs()
    {
        for (int i = 0; i < TabPanels.Count; i++)
        {
            TabPanels[i].SetActive(false);
        }
    }

    public void EnableTab(int index)
    {
        TabPanels[index].SetActive(true);
    }
}
