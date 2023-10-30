
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using GooglePlayGames;
using GooglePlayGames.BasicApi;
 
public class FirebaseGoogleAuth : MonoBehaviour
{
    public Text email;
 
    void Start()
    {
        PlayGamesPlatform.InitializeInstance(new PlayGamesClientConfiguration.Builder().Build());
        PlayGamesPlatform.DebugLogEnabled = true;
        PlayGamesPlatform.Activate();
        // Google Play Games Ȱ��ȭ
    }
 
 
    public void TryGoogleLogin()
    {
        if (!Social.localUser.authenticated) // �α��� �Ǿ� ���� �ʴٸ�
        {
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
}