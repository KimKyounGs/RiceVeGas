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
        Debug.Log("게임 접속 햇을 때");

        count++;
        Debug.Log(count);
        GameObject PI = PhotonNetwork.Instantiate("Player", Vector3.zero, Quaternion.identity);
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

}
