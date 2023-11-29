using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceManager : MonoBehaviour
{
    public static DiceManager instance;

    [SerializeField] private List<GameObject> dice = new List<GameObject>();
    void Start()
    {
        instance = this;
    }

    void Update()
    {
        
    }
}
