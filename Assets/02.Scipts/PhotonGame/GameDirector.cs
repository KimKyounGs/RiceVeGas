using System.Collections;
using System.Collections.Generic;
using System.Data;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine;


public class GameDirector : MonoBehaviour
{
    private void Start()
    {
        PhotonNetwork.ConnectUsingSettings(); // ������ ���� Photon ������ ���� --> ������ ������ ����. d
    }
}