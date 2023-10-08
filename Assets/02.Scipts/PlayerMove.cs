using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;

public class PlayerMove : MonoBehaviourPun
{
    private float moveSpeed = 5f;

    void Update()
    {
        if (photonView.IsMine)
        {
            float x = Input.GetAxis("Horizontal");
            float z = Input.GetAxis("Vertical");
            
            transform.Translate(new Vector3(x, 0, z) * moveSpeed * Time.deltaTime);
        }
    }
}
