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
        // Google Play Games Ȱ��ȭ

        // PlayGamesClientConfiguration.Builder()�� ����Ͽ� Google Play Games Ŭ���̾�Ʈ�� ������ �����մϴ�.
        // ���⼭�� �⺻ ������ ����Ͽ� Builder �ν��Ͻ��� ����ϴ�.  Build() �޼ҵ带 ȣ���Ͽ� ������ �����ϰ�, �̸� InitializeInstance() �޼ҵ忡 �����Ͽ� Play Games �÷����� �ν��Ͻ��� �ʱ�ȭ�մϴ�. 
        // �̰��� ������ ������ �� �� ���� ȣ��Ǿ�� �մϴ�.
        PlayGamesPlatform.InitializeInstance(new PlayGamesClientConfiguration.Builder().Build());

        // Google Play Games �÷����� ����� �α׸� Ȱ��ȭ�մϴ�. 
        // �̴� ���� �� ������ ������ �� �����ϸ�, ���� ���� ��� �ÿ��� ��Ȱ��ȭ�ϴ� ���� �Ϲ����Դϴ�.
        PlayGamesPlatform.DebugLogEnabled = true;

        // ������ Google Play Games ���񽺿� ��ȣ �ۿ��ϴ� �� ���� �� �ֵ��� �մϴ�.
        PlayGamesPlatform.Activate();

        
    }

    public void TryGoogleLogin()
    {
        if (!Social.localUser.authenticated) // �α��� �Ǿ� ���� �ʴٸ�
        {
            SceneManager.LoadScene("LobbyScene");
            Social.localUser.Authenticate(success => // �α��� �õ�
            {
                if (success) // �����ϸ�
                {
                    email.text = Social.localUser.userName; 

                }
                else // �����ϸ�
                {
                    email.text = "Fail...";
                }
            });
        }
    }

    public void TryGoogleLogout()
    {
        if (Social.localUser.authenticated) // �α��� �Ǿ� �ִٸ�
        {
            PlayGamesPlatform.Instance.SignOut(); // �α׾ƿ�
            email.text = "Logout";
        }
    }

    public void SettingUI(int type) 
    {
        
    }

}