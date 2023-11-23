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
        PhotonNetwork.ConnectUsingSettings(); // 설정에 따라 Photon 서버에 연결 --> 마스터 서버에 접속. d
    }
}