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

    private void Start()
    {
        if (PhotonNetwork.IsConnectedAndReady)
        {
            Spawn();
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
    void Spawn()
    {
        PhotonView[] photonViews = FindObjectsOfType<PhotonView>();
        int playerCount = 0;

        foreach (var view in photonViews)
        {
            if (view.IsMine)
            {
                playerCount++;
            }
        }

        Debug.Log("현재 씬에 있는 플레이어 수: " + playerCount);
    }
    
}
