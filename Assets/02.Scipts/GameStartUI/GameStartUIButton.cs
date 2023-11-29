using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Photon.Pun;
using Photon.Realtime;
using Photon.Pun.UtilityScripts;

public class GameStartUIButton : MonoBehaviourPun
{
    public PhotonView PV;
    public GameObject Button;
    public GameObject startPanel;
    public GameObject ReadyPanel;
    public GameObject InGamePanel;
    //public GameObject gamePlayObject;

    public void StartGameHandler()
    {
        PV = GetComponent<PhotonView>();
        startPanel.SetActive(false);    //시작 패널 닫고
        InGamePanel.SetActive(true);    //인게임 패널 오픈
        //StartManager gamePlayScript = gamePlayObject.GetComponent<StartManager>();
        //gamePlayScript.ResumeTime();

        PV.RPC("CloseReadyPanel", RpcTarget.All);
    }

    public void ExitGameHandler()
    {
        SceneManager.LoadScene("LobbyScene");
    }

    [PunRPC]
    public void CloseReadyPanel()
    {
        // "Ready" 패널을 닫음
        ReadyPanel.SetActive(false);
        InGamePanel.SetActive(true);
    }
}

