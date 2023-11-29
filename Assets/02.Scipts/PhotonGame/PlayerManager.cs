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
    public PhotonView PV;

    private void Start()
    {
        if (PhotonNetwork.IsConnectedAndReady)
        {
            Spawn();
        }
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            PV.RPC("DisplayMessage", RpcTarget.All, "Hello, World!");
        }
    }

    [PunRPC]
    public void DisplayMessage(string message)
    {
        Debug.Log("Received message: " + message);
    }

    void Spawn()
    {
        int playerCount = PhotonNetwork.CurrentRoom.PlayerCount;
        Debug.Log("현재 방의 플레이어 수: " + playerCount);

    }
    
}
