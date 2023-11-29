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
        startPanel.SetActive(false);    //���� �г� �ݰ�
        InGamePanel.SetActive(true);    //�ΰ��� �г� ����
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
        // "Ready" �г��� ����
        ReadyPanel.SetActive(false);
        InGamePanel.SetActive(true);
    }
}

