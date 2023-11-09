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
        PhotonNetwork.ConnectUsingSettings(); // 설정에 따라 Photon 서버에 연결 --> 마스터 서버에 접속.
    }

    public override void OnConnectedToMaster()
    {
        Debug.Log("Connected to Photon Server!");
        PhotonNetwork.JoinLobby(); // 마스터 서버에 연결되면 로비에 조인
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
        string roomName = roomNameInputField.text; // InputField로부터 방 제목을 가져옵니다.
        if (!string.IsNullOrEmpty(roomName)) // 방 제목이 비어있지 않은 경우에만 방을 생성합니다.
        {
            // 방의 최대 플레이어 수, 방이 공개적으로 검색 가능한지 여부, 방에 입장할 수 있는 조건 등을 설정할 수 있습니다.
            RoomOptions roomOptions = new RoomOptions();
            roomOptions.MaxPlayers = 6; // 방의 최대 플레이어 수 설정
            PhotonNetwork.CreateRoom(roomName, roomOptions); // 방을 생성합니다.
        }
        else
        {
            Debug.LogError("Room name is empty or null. Please enter a room name."); // 방 제목이 비어있는 경우 오류 메시지를 출력합니다.
        }
    }

    // OnCreatRoom, OnCreateRoomFailed는 포톤의 콜백함수이다.
    public override void OnCreatedRoom()
    {
        Debug.Log("Created Room: " + PhotonNetwork.CurrentRoom.Name);
    }

    // 방 만들기에 실패한 경우
    public override void OnCreateRoomFailed(short returnCode, string message)
    {
        Debug.Log("Room Creation Failed: " + message);
    }

    public void SettingUI(int type, bool flag) 
    {
        switch(type) 
        {
            // RoomCreate 옵션
            case 1: 
            {
                roomOption.SetActive(flag);
                break;    
            }
        }
    }
}
