using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using Photon.Pun;
using Photon.Realtime;

public class StartManager : MonoBehaviour
{
    public GameObject startPanel;
    public GameObject GamePanel;
    private Transform parentObject;
    void Start()
    {
        
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            RestartGame();
            startPanel.SetActive(true);
        }

        if (Input.GetKeyDown(KeyCode.T))
        {
            if (PhotonNetwork.IsMasterClient)
            {
                Debug.Log("내가 방장이다.");// 현재 플레이어가 방장일 때 수행할 작업
            }
            else 
            {
                Debug.Log("내가 방장이 아니다.");
            }
        }
    }

    public void ResumeTime()
    {
        Time.timeScale = 1.0f;
    }   

    void RestartGame()
    {
        DestroyAllGameObjects();

        Instantiate(GamePanel, transform.position, Quaternion.identity, transform);
    }

    void DestroyAllGameObjects()
    {
        {
            if (parentObject == null)
            {
                parentObject = transform;
            }

            foreach (Transform child in parentObject)
            {
                Destroy(child.gameObject);
            }
        }
    }
}
