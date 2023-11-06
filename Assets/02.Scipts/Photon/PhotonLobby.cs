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
    }

    public void CreateRoomOption()
    {
        roomOption.SetActive(true);
        
    }
    // 방 만들기 버튼을 위한 메서드
    public void CreateRoom()
    {
        // 방의 최대 플레이어 수, 방이 공개적으로 검색 가능한지 여부, 방에 입장할 수 있는 조건 등을 설정할 수 있습니다.

        RoomOptions roomOptions = new RoomOptions();
        roomOptions.MaxPlayers = 6; // 방의 최대 플레이어 수 설정
        
        // 무작위 방 이름을 생성합니다.
        string roomName = "Room " + Random.Range(1000, 10000);
        
        // 방 만들기 시도
        PhotonNetwork.CreateRoom(roomName, roomOptions);
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
}
