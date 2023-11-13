using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStartUIButton : MonoBehaviour
{
    public GameObject Button;
    public GameObject startPanel;
    public GameObject gamePlayObject;

    public void StartGameHandler()
    {
        startPanel.SetActive(false);
        StartManager gamePlayScript = gamePlayObject.GetComponent<StartManager>();
        gamePlayScript.ResumeTime();
    }

    public void ExitGameHandler()
    {
        SceneManager.LoadScene("LobbyScene");
    }
}
