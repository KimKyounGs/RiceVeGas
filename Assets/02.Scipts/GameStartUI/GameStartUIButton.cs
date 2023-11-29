using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Photon.Pun;
using Photon.Realtime;
using Photon.Pun.UtilityScripts;

public class GameStartUIButton : MonoBehaviourPunCallbacks
{
    public PhotonView photonView;
    public GameObject Button;
    public GameObject startPanel;
    public GameObject InGamePanel;
    //public GameObject gamePlayObject;

    public void StartGameHandler()
    {
        photonView = GetComponent<PhotonView>();
        startPanel.SetActive(false);    //시작 패널 닫고
        InGamePanel.SetActive(true);    //인게임 패널 오픈
        //StartManager gamePlayScript = gamePlayObject.GetComponent<StartManager>();
        //gamePlayScript.ResumeTime();

        photonView.RPC("DisableReadyUI", RpcTarget.All);
    }

    public void ExitGameHandler()
    {
        SceneManager.LoadScene("LobbyScene");
    }

    [PunRPC]
    public void DisableReadyUI()
    {
        // 여기에서 다른 플레이어들의 레디 UI를 비활성화
        // 예를 들어, 모든 플레이어의 레디 UI가 ReadyPanel이라 가정하면:
        GameObject[] readyPanels = GameObject.FindGameObjectsWithTag("ReadyPanel");

        foreach (GameObject panel in readyPanels)
        {
            panel.SetActive(false);
        }
    }
}

