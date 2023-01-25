using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Mirror;

public class MenuUI : MonoBehaviour
{
    // UI elements
    [SerializeField] private TMPro.TMP_Text playerNameTxt;

    private GameObject menuPlayer;
    private PlayerData menuPlayerData;

    public void OnClickHostBtn()
    {
        NetworkManager.singleton.StartHost();
    }

    public void OnClickJoinBtn()
    {
        NetworkManager.singleton.StartClient();
    }
}
