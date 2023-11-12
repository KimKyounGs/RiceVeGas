using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine;
using UnityEngine.UI;


public class PhotonLobby : MonoBehaviourPunCallbacks
{
    [SerializeField] private GameObject roomOptionObj;
    [SerializeField] private InputField roomNameInputField;

    [SerializeField] private GameObject findRoomObj;
    [SerializeField] private InputField findRoomNameInputField;
    [SerializeField] private Text findRoomAnnounce;

    private bool bPlayerDoing;
    private void Start()
    {
        PhotonNetwork.ConnectUsingSettings(); // 설정에 따라 Photon 서버에 연결 --> 마스터 서버에 접속. d
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            
        }
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

            roomNameInputField.text = "";
        }
    }

    public void OffCreateRoomButtonClicked() 
    {
        if (bPlayerDoing)
        {
            SettingUI(1, false);
            bPlayerDoing = false;
        }
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

    public void OnFindRoomButtonClicked()
    {
        if (!bPlayerDoing)
        {
            SettingUI(2, true);
            bPlayerDoing = true;

            findRoomAnnounce.text = "";
            findRoomNameInputField.text = "";
        }
    }

    public void OffFindRoomButtonClicked()
    {
        if (bPlayerDoing)
        {
            SettingUI(2, false);
            bPlayerDoing = false;
        }
    }

    public void FindRoom()
    {
        string findRoomName = findRoomNameInputField.text; 
        if (!string.IsNullOrEmpty(findRoomName))
        {
            PhotonNetwork.JoinRoom(findRoomName); // 포톤 방에 입장을 시도합니다.
        }
        else 
        {
            findRoomAnnounce.text = "방의 제목을 입력해주세요.";
        }
    }
    
    // 해당 방에 성공적으로 입장했을 때 호출됩니다.
    public override void OnJoinedRoom()
    {
        Debug.Log("방에 입장했습니다.");
        findRoomAnnounce.text = "";
    }

    // 방에 입장하지 못했을 때 호출됩니다.
    public override void OnJoinRoomFailed(short returnCode, string message)
    {
        Debug.Log("방에 입장하는 데 실패했습니다: " + message);
        findRoomAnnounce.text = "해당 방이 존재하지 않습니다 !";
    }

    // 방 목록이 업데이트될 때마다 호출되는 콜백
    public override void OnRoomListUpdate(List<RoomInfo> roomList)
    {
        Debug.Log("Update RommList");
        foreach (RoomInfo room in roomList)
        {
            Debug.Log("방 이름: " + room.Name + ", 플레이어 수: " + room.PlayerCount + "/" + room.MaxPlayers);
        }
    }

    public void SettingUI(int type, bool flag) 
    {
        switch(type) 
        {
            // RoomCreate 옵션
            case 1: 
            {
                roomOptionObj.SetActive(flag);
                break;    
            }
            case 2:
            {
                findRoomObj.SetActive(flag);
                break;
            }
        }
    }
}
