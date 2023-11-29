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
    public GameObject StartUI;
    public GameObject ReadyUI;
    private Transform parentObject;
    void Start()
    {
        if (PhotonNetwork.IsMasterClient)
        {
            StartUI.SetActive(true);
        }
        else
        {
            ReadyUI.SetActive(true);
        }
    }


    void Update()
    {
        
    }

    public void ResumeTime()
    {
        Time.timeScale = 1.0f;
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
