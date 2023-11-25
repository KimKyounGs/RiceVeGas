using System.Collections;
using System.Collections.Generic;
using System.Data;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine;


public class GameDirector : MonoBehaviourPun
{
    public static GameDirector instance;

    [SerializeField] private List<GameObject> dice = new List<GameObject>();

    private void Start()
    {
        instance = this;
    }

    public void DistributeDice()
    {
        
    }
}