using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using GooglePlayGames;
using GooglePlayGames.BasicApi;
using UnityEngine.SceneManagement;

 
public class GoogleAuth : MonoBehaviour
{
    public Text email;

    void Start()
    {
        // Google Play Games 활성화

        // PlayGamesClientConfiguration.Builder()를 사용하여 Google Play Games 클라이언트의 설정을 구성합니다.
        // 여기서는 기본 설정을 사용하여 Builder 인스턴스를 만듭니다.  Build() 메소드를 호출하여 설정을 구축하고, 이를 InitializeInstance() 메소드에 전달하여 Play Games 플랫폼의 인스턴스를 초기화합니다. 
        // 이것은 게임이 시작할 때 한 번만 호출되어야 합니다.
        PlayGamesPlatform.InitializeInstance(new PlayGamesClientConfiguration.Builder().Build());

        // Google Play Games 플랫폼의 디버그 로그를 활성화합니다. 
        // 이는 개발 중 문제를 진단할 때 유용하며, 실제 게임 출시 시에는 비활성화하는 것이 일반적입니다.
        PlayGamesPlatform.DebugLogEnabled = true;

        // 실제로 Google Play Games 서비스와 상호 작용하는 데 사용될 수 있도록 합니다.
        PlayGamesPlatform.Activate();

        
    }

    public void TryGoogleLogin()
    {
        if (!Social.localUser.authenticated) // 로그인 되어 있지 않다면
        {
            SceneManager.LoadScene("LobbyScene");
            Social.localUser.Authenticate(success => // 로그인 시도
            {
                if (success) // 성공하면
                {
                    email.text = Social.localUser.userName; 

                }
                else // 실패하면
                {
                    email.text = "Fail...";
                }
            });
        }
    }

    public void TryGoogleLogout()
    {
        if (Social.localUser.authenticated) // 로그인 되어 있다면
        {
            PlayGamesPlatform.Instance.SignOut(); // 로그아웃
            email.text = "Logout";
        }
    }

    public void SettingUI(int type) 
    {
        
    }

}