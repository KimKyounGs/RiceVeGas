using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine;
using UnityEngine.UI;


public class PhotonLobby : MonoBehaviourPunCallbacks
{

    [SerializeField] private GameObject gameStartObj;

    [SerializeField] private GameObject roomCreatOptionObj;
    [SerializeField] private InputField roomNameInputField;

    [SerializeField] private GameObject findRoomObj;
    [SerializeField] private InputField findRoomNameInputField;
    [SerializeField] private Text findRoomAnnounce;

    private bool bPlayerDoing;
    private bool isRoomCreator = false;
    private void Start()
    {
        PhotonNetwork.ConnectUsingSettings(); // 설정에 따라 Photon 서버에 연결 --> 마스터 서버에 접속. d
    }

    private void Update()
    { 
        
    }

    /// <summary>
    /// 포톤 연결
    /// </summary>
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

    /// <summary>
    /// 방 목록 보기.
    /// </summary>
    /// <param name="roomList"></param>

    // 방 목록이 업데이트될 때마다 호출되는 콜백
    public override void OnRoomListUpdate(List<RoomInfo> roomList)
    {
        Debug.Log("방 리스트 보기.");
        foreach (RoomInfo room in roomList)
        {
            Debug.Log("방 이름: " + room.Name + ", 플레이어 수: " + room.PlayerCount + "/" + room.MaxPlayers);
        }
    }

    public void OnGameStartButtonClicked()
    {
        if (!bPlayerDoing)
        {
            SettingUI(0, true);
            bPlayerDoing = true;
        }
    }

    public void OffGameStartButtonClicked()
    {
        if (bPlayerDoing)
        {
            SettingUI(0, false);
            bPlayerDoing = false;
        }
    }

    /// <summary>
    /// 방 만들기.
    /// </summary>
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

        Debug.Log("방을 만듭니다.");
        isRoomCreator = true; // 방을 만든 사용자로 설정
        // 방 생성 후 게임 씬 로드 (각각 방 마다 씬을 따로 관리)
        PhotonNetwork.LoadLevel("GameScene");
    }

    // 방 만들기에 실패한 경우
    public override void OnCreateRoomFailed(short returnCode, string message)
    {
        Debug.Log("Room Creation Failed: " + message);
    }
    
    /// <summary>
    /// 방 찾기.
    /// </summary>
    public void OnFindRoomButtonClicked()
    {
        if (!bPlayerDoing)
        {
            SettingUI(2, true);
            bPlayerDoing = true;

            // 초기화
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
            findRoomAnnounce.text = "방의 제목을 입력해주세요!";
        }
    }
    
    // 해당 방에 성공적으로 입장했을 때 호출됩니다.
    public override void OnJoinedRoom()
    {
        if (isRoomCreator)
        {
            Debug.Log("방을 만든 사용자가 방에 입장했습니다.");
            findRoomAnnounce.text = "";
        }
        else
        {
            Debug.Log("다른 사용자가 방에 입장했습니다.");
            PhotonNetwork.LoadLevel("GameScene");
            // 다른 사용자의 로직 처리
        }
    }

    // 방에 입장하지 못했을 때 호출됩니다.
    public override void OnJoinRoomFailed(short returnCode, string message)
    {
        Debug.Log("방에 입장하는 데 실패했습니다: " + message);
        findRoomAnnounce.text = "해당 방이 존재하지 않습니다 !";
    }

    /// <summary>
    /// UI 담당.
    /// </summary>
    public void SettingUI(int type, bool flag) 
    {
        switch(type) 
        {
            // RoomList On/Off
            case 0:
            {
                gameStartObj.SetActive(flag);
                break;
            }
            // roomCreat On/Off
            case 1: 
            {
                roomCreatOptionObj.SetActive(flag);
                break;    
            }
            // findRoom On/Off
            case 2:
            {
                findRoomObj.SetActive(flag);
                break;
            }
        }
    }
}