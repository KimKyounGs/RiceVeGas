using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Money
{
    [Tooltip("돈 얼마 ?")]
    private int _price;

    [Tooltip("돈 프리팹")]
    private GameObject _prefab;

    [Tooltip("돈 뒤집을 것이냐 ?")]
    private bool _bFlip;
    // 카드 분배.
    public void DistributeMoney() 
    {
        
    }
}
