using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine;

/// <summary>
/// 플레이어의 상태, 순서, 배팅 금액 등을 관리합니다.
/// </summary>


public class PlayerManager : MonoBehaviourPun
{
    List<Player> playerList = new List<Player>();
    public static int count = 0;
    private void Start()
    {
        PlayerManager[] scripts = FindObjectsOfType<PlayerManager>();
        Debug.Log("씬에 존재하는 MyScript 개수: " + scripts[0]);
        if (PhotonNetwork.IsConnectedAndReady)
        {
            Debuging();
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            photonView.RPC("DisplayMessage", RpcTarget.All, "Hello, World!");
        }
    }

    [PunRPC]
    void DisplayMessage(string message)
    {
        Debug.Log("Received message: " + message);
    }
       
    void Debuging()
    {
        count++;
        Debug.Log("count = " + count);
    }
}
