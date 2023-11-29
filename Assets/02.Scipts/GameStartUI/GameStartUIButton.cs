using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Photon.Pun;
using Photon.Realtime;

public class GameStartUIButton : MonoBehaviourPun
{
    public GameObject Button;
    public GameObject startPanel;
    public GameObject InGamePanel;
    //public GameObject gamePlayObject;

    public void StartGameHandler()
    {
        startPanel.SetActive(false);    //���� �г� �ݰ�
        InGamePanel.SetActive(true);    //�ΰ��� �г� ����
        //StartManager gamePlayScript = gamePlayObject.GetComponent<StartManager>();
        //gamePlayScript.ResumeTime();

        photonView.RPC("DisableReadyUI", RpcTarget.All);
    }

    public void ExitGameHandler()
    {
        SceneManager.LoadScene("LobbyScene");
    }

    void DisableReadyUI()
    {
        // ���⿡�� �ٸ� �÷��̾���� ���� UI�� ��Ȱ��ȭ
        // ���� ���, ��� �÷��̾��� ���� UI�� ReadyPanel�̶� �����ϸ�:
        GameObject[] readyPanels = GameObject.FindGameObjectsWithTag("ReadyPanel");

        foreach (GameObject panel in readyPanels)
        {
            panel.SetActive(false);
        }
    }
}

