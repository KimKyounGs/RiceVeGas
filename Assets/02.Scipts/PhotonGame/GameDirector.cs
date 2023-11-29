using System.Collections;
using System.Collections.Generic;
using System.Data;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine;


public class GameDirector : MonoBehaviourPun
{
    public static GameDirector instance;

    private void Start()
    {
        instance = this;
    }

    public void DistributeDice()
    {
        
    }
}