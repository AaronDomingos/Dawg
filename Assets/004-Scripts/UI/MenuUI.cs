using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Mirror;

public class MenuUI : MonoBehaviour
{
    public void OnClickHostBtn()
    {
        NetworkManager.singleton.StartHost();
    }

    public void OnClickJoinBtn()
    {
        NetworkManager.singleton.StartClient();
    }
}
