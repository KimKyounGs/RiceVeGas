using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

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
