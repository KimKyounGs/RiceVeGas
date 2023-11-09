using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine;
using UnityEngine.UI;


public class PhotonLobby : MonoBehaviourPunCallbacks
{
    [SerializeField] private GameObject roomOption;
    [SerializeField] private InputField roomNameInputField;

    private bool bPlayerDoing;
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
        bPlayerDoing = false;
    }

    public void OnCreateRoomButtonClicked()
    {
        if (!bPlayerDoing)
        {
            SettingUI(1, true);
            bPlayerDoing = true;
        }
    }

    public void OFFCreateRoomButtonClicked() 
    {
        SettingUI(1, false);
        bPlayerDoing = false;
    }
    
    public void CreateRoom()
    {
        string roomName = roomNameInputField.text; // InputField�κ��� �� ������ �����ɴϴ�.
        if (!string.IsNullOrEmpty(roomName)) // �� ������ ������� ���� ��쿡�� ���� �����մϴ�.
        {
            // ���� �ִ� �÷��̾� ��, ���� ���������� �˻� �������� ����, �濡 ������ �� �ִ� ���� ���� ������ �� �ֽ��ϴ�.
            RoomOptions roomOptions = new RoomOptions();
            roomOptions.MaxPlayers = 6; // ���� �ִ� �÷��̾� �� ����
            PhotonNetwork.CreateRoom(roomName, roomOptions); // ���� �����մϴ�.
        }
        else
        {
            Debug.LogError("Room name is empty or null. Please enter a room name."); // �� ������ ����ִ� ��� ���� �޽����� ����մϴ�.
        }
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

    public void SettingUI(int type, bool flag) 
    {
        switch(type) 
        {
            // RoomCreate �ɼ�
            case 1: 
            {
                roomOption.SetActive(flag);
                break;    
            }
        }
    }
}
