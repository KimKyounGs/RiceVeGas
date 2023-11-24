using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine;


public class PlayerControl : MonoBehaviourPun
{
    private void Start()
    {
        Debug.Log("게임 접속 햇을 때");
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
