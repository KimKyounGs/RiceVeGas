using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine;


public class PlayerControl : MonoBehaviourPun
{
    private void Start()
    {
        Debug.Log("���� ���� ���� ��");
        GameObject PI = PhotonNetwork.Instantiate("Player", Vector3.zero, Quaternion.identity);
    }

}
