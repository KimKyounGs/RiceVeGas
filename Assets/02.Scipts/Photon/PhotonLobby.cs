using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine;
using UnityEngine.UI;


public class PhotonLobby : MonoBehaviourPunCallbacks
{
    public GameObject roomOption;
    public InputField roomNameInputField;

    private void Start()
    {
        PhotonNetwork.ConnectUsingSettings(); // ������ ���� Photon ������ ���� --> ������ ������ ����.
    }

    public override void OnConnectedToMaster()
    {
        Debug.Log("Connected to Photon Server!");
        PhotonNetwork.JoinLobby(); // ������ ������ ����Ǹ� �κ� ����
    }

    public override void OnJoinedLobby()
    {
        Debug.Log("Joined Lobby!");
    }

    public void CreateRoomOption()
    {
        roomOption.SetActive(true);
        
    }
    // �� ����� ��ư�� ���� �޼���
    public void CreateRoom()
    {
        // ���� �ִ� �÷��̾� ��, ���� ���������� �˻� �������� ����, �濡 ������ �� �ִ� ���� ���� ������ �� �ֽ��ϴ�.

        RoomOptions roomOptions = new RoomOptions();
        roomOptions.MaxPlayers = 6; // ���� �ִ� �÷��̾� �� ����
        
        // ������ �� �̸��� �����մϴ�.
        string roomName = "Room " + Random.Range(1000, 10000);
        
        // �� ����� �õ�
        PhotonNetwork.CreateRoom(roomName, roomOptions);
    }

    // OnCreatRoom, OnCreateRoomFailed�� ������ �ݹ��Լ��̴�.
    public override void OnCreatedRoom()
    {
        Debug.Log("Created Room: " + PhotonNetwork.CurrentRoom.Name);
    }

    // �� ����⿡ ������ ���
    public override void OnCreateRoomFailed(short returnCode, string message)
    {
        Debug.Log("Room Creation Failed: " + message);
    }
}
